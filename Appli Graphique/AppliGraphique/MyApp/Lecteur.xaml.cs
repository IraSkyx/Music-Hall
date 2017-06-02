using Biblio;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Windows.Threading;
using BackEnd;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Lecteur.xaml
    /// </summary>
    public partial class Lecteur : UserControl
    {                
        private DispatcherTimer timer = new DispatcherTimer();

        public static readonly DependencyProperty Playlist = DependencyProperty.Register("MyPlaylist", typeof(ListView), typeof(Lecteur));
        public ListView MyPlaylist
        {
            get
            {
                return GetValue(Playlist) as ListView;
            }
            set
            {
                SetValue(Playlist, value);
            }
        }

        public static readonly DependencyProperty Scroller = DependencyProperty.Register("MyScroller", typeof(ListView), typeof(Lecteur));
        public ListView MyScroller
        {
            get
            {
                return GetValue(Scroller) as ListView;
            }
            set
            {
                SetValue(Scroller, value);
            }
        }

        /// <summary>
        /// Instancie Lecteur, ajoute dynamiquement un Player, fixe les évènements du Player, définit les paramètres du Timer et les DataContext de la vue
        /// </summary>
        public Lecteur()
        {
            InitializeComponent();            

            FullPlayer.Children.Add(PlayerFront.MyPlayer);

            FullPlayer.DataContext = PlayerFront.MyPlayer;

            PlayerFront.MyPlayer.MediaEnded += MediaEnded;
            PlayerFront.MyPlayer.MediaOpened += MediaOpened;

            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(Update);
            timer.Start();
        }

        /// <summary>
        /// Met à jour les durées actuelles et maximales d'une Music en cours de lecture 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Update(object sender, EventArgs e)
        {
            if (PlayerFront.MyPlayer.NaturalDuration.HasTimeSpan)
            {
                Prog.Value = PlayerFront.MyPlayer.Position.TotalSeconds;
                duration.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    PlayerFront.MyPlayer.Position.Hours,
                    PlayerFront.MyPlayer.Position.Minutes,
                    PlayerFront.MyPlayer.Position.Seconds);
                duration2.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    PlayerFront.MyPlayer.NaturalDuration.TimeSpan.Hours,
                    PlayerFront.MyPlayer.NaturalDuration.TimeSpan.Minutes,
                    PlayerFront.MyPlayer.NaturalDuration.TimeSpan.Seconds);
            }
        }

        /// <summary>
        /// Définit les valeurs de la ProgressBar et le DataContext la miniature
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            if (PlayerFront.MyPlayer.NaturalDuration.HasTimeSpan)
            {
                Prog.Minimum = 0;
                Prog.Maximum = PlayerFront.MyPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                ActualPlay.DataContext = PlayerFront.MyPlayer.CurrentlyPlaying;
            }       
        }

        /// <summary>
        /// Lis ou mets en pause le Player
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void PausePlayClick(object sender, RoutedEventArgs e)
        {
            if(!ReferenceEquals(PlayerFront.MyPlayer.CurrentlyPlaying, null))
            {
                if (PlayerFront.MyPlayer.IsPlaying)
                {
                    PlayerFront.MyPlayer.Pause();
                    PlayerFront.MyPlayer.IsPlaying = false;
                }
                else
                {
                    if (PlayerFront.MyPlayer.NaturalDuration.TimeSpan.TotalSeconds == PlayerFront.MyPlayer.Position.TotalSeconds)
                        PlayerFront.MyPlayer.ChangePosition(TimeSpan.Zero);
                    else
                    {
                        PlayerFront.MyPlayer.Play();
                        PlayerFront.MyPlayer.IsPlaying = true;
                    }                 
                }
            }
        }

        /// <summary>
        /// Active l'option lecture en boucle
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Replay(object sender, RoutedEventArgs e) 
            => PlayerFront.MyPlayer.Loop=!PlayerFront.MyPlayer.Loop;

        /// <summary>
        /// Active l'option lecture aléatoire
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Random(object sender, RoutedEventArgs e) 
            => PlayerFront.MyPlayer.RandomPlay=!PlayerFront.MyPlayer.RandomPlay;

        /// <summary>
        /// Désactive/active le son
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Mute(object sender, MouseButtonEventArgs e)
            => PlayerFront.MyPlayer.Volume = PlayerFront.MyPlayer.Volume == 0.00 ? 0.50 : 0.00;

        /// <summary>
        /// Passe à la Music suivante/précédente
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void NextAndPrevious(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ReferenceEquals(sender,next))
                    PlayerFront.MyPlayer.GoToNextOrPrevious(1);
                else
                    PlayerFront.MyPlayer.GoToNextOrPrevious(-1);
            }
            catch (NullReferenceException)
            {
                PlayerFront.MyPlayer.IsPlaying = false;
                PlayerFront.MyPlayer.Pause();
                return;
            }
        }

        /// <summary>
        /// Définit le comportement du Player pour la prochaine lecture 
        /// => Relecture
        /// => Lecture de la prochaine Music
        /// => Pause
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            if (PlayerFront.MyPlayer.Loop)
                PlayerFront.MyPlayer.ChangePosition(TimeSpan.Zero);
            else
                NextAndPrevious(this, new RoutedEventArgs());
        }

        /// <summary>
        /// Change la position de la Music actuellement lue d'après la position X du clic dans la ProgressBar (Produit en croix)
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void ProgMouseClick(object sender, MouseButtonEventArgs e)
        {
            if (!ReferenceEquals(PlayerFront.MyPlayer.Source,null) && PlayerFront.MyPlayer.NaturalDuration.HasTimeSpan)
                PlayerFront.MyPlayer.ChangePosition(new TimeSpan(0, 0, (int)((e.GetPosition(Prog).X / Prog.ActualWidth) * Prog.Maximum)));
        }

        /// <summary>
        /// Ajoute une Music à la playlist User (si connecté) tout en instanciant si nécessaire
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (!ReferenceEquals(PlayerFront.MyPlayer.CurrentUser,null))
            {
                if (ReferenceEquals(PlayerFront.MyPlayer.CurrentUser.Favorite,null))
                    PlayerFront.MyPlayer.CurrentUser.Favorite = new Playlist();
                if (PlayerFront.MyPlayer.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals(PlayerFront.MyPlayer.CurrentlyPlaying)) == 0)
                    PlayerFront.MyPlayer.CurrentUser.Favorite.PlaylistProperty.Add(PlayerFront.MyPlayer.CurrentlyPlaying);
            }
            Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }

        /// <summary>
        /// Permet de consulter la Music actuellement lue ou celle sélectionnée dans sa playlist
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void SeeMusic(object sender, MouseButtonEventArgs e)
        {
            if (!ReferenceEquals(MyPlaylist.SelectedItem, null) && ReferenceEquals(sender, MyPlaylist))
                MyScroller.SelectedIndex = PlaylistFront.AllMusics.Index((IMusic)MyPlaylist.SelectedItem);

            if (ReferenceEquals(sender, ActualPlay) && !ReferenceEquals(PlayerFront.MyPlayer.CurrentlyPlaying, null))
                MyScroller.SelectedIndex = PlaylistFront.AllMusics.Index(PlayerFront.MyPlayer.CurrentlyPlaying);
        }
    }
}
