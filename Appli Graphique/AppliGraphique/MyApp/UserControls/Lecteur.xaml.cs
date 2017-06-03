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
        public PlayerFront Front { get; set; } = new PlayerFront();
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

            Add1.DataContext = Front;

            FullPlayer.DataContext = Front.MyPlayer;

            Front.MyPlayer.MediaEnded += MediaEnded;
            Front.MyPlayer.MediaOpened += MediaOpened;

            FullPlayer.Children.Add(Front.MyPlayer);

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
            if (Front.MyPlayer.NaturalDuration.HasTimeSpan)
            {
                Prog.Value = Front.MyPlayer.Position.TotalSeconds;
                duration.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    Front.MyPlayer.Position.Hours,
                    Front.MyPlayer.Position.Minutes,
                    Front.MyPlayer.Position.Seconds);
                duration2.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    Front.MyPlayer.NaturalDuration.TimeSpan.Hours,
                    Front.MyPlayer.NaturalDuration.TimeSpan.Minutes,
                    Front.MyPlayer.NaturalDuration.TimeSpan.Seconds);
            }
        }

        /// <summary>
        /// Définit les valeurs de la ProgressBar et le DataContext de la miniature
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            if (Front.MyPlayer.NaturalDuration.HasTimeSpan)
            {
                Prog.Minimum = 0;
                Prog.Maximum = Front.MyPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                ActualPlay.DataContext = Front.MyPlayer.CurrentlyPlaying;
                Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
                Add1.GetBindingExpression(VisibilityProperty).UpdateTarget();
            }       
        }

        /// <summary>
        /// Lis ou mets en pause le Player
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void PausePlayClick(object sender, RoutedEventArgs e)
        {
            if(!ReferenceEquals(Front.MyPlayer.CurrentlyPlaying, null))
            {
                if (Front.MyPlayer.IsPlaying)
                {
                    Front.MyPlayer.Pause();
                    Front.MyPlayer.IsPlaying = false;
                }
                else
                {
                    if (Front.MyPlayer.NaturalDuration.TimeSpan.TotalSeconds == Front.MyPlayer.Position.TotalSeconds)
                        Front.MyPlayer.ChangePosition(TimeSpan.Zero);
                    else
                    {
                        Front.MyPlayer.Play();
                        Front.MyPlayer.IsPlaying = true;
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
            => Front.MyPlayer.Loop=!Front.MyPlayer.Loop;

        /// <summary>
        /// Active l'option lecture aléatoire
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Random(object sender, RoutedEventArgs e) 
            => Front.MyPlayer.RandomPlay=!Front.MyPlayer.RandomPlay;

        /// <summary>
        /// Désactive/active le son
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Mute(object sender, MouseButtonEventArgs e)
            => Front.MyPlayer.Volume = Front.MyPlayer.Volume == 0.00 ? 0.50 : 0.00;

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
                    Front.MyPlayer.GoToNextOrPrevious(1);
                else
                    Front.MyPlayer.GoToNextOrPrevious(-1);
            }
            catch (NullReferenceException)
            {
                Front.MyPlayer.IsPlaying = false;
                Front.MyPlayer.Pause();
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
            if (Front.MyPlayer.Loop)
                Front.MyPlayer.ChangePosition(TimeSpan.Zero);
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
            if (!ReferenceEquals(Front.MyPlayer.Source,null) && Front.MyPlayer.NaturalDuration.HasTimeSpan)
                Front.MyPlayer.ChangePosition(new TimeSpan(0, 0, (int)((e.GetPosition(Prog).X / Prog.ActualWidth) * Prog.Maximum)));
        }

        /// <summary>
        /// Ajoute une Music à la playlist User (si connecté) tout en instanciant si nécessaire
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (!ReferenceEquals(Front.MyPlayer.CurrentUser,null))
            {
                if (Front.MyPlayer.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals(Front.MyPlayer.CurrentlyPlaying)) == 0)
                    Front.MyPlayer.CurrentUser.Favorite.PlaylistProperty.Add(Front.MyPlayer.CurrentlyPlaying);
            }
            Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
            Add1.GetBindingExpression(VisibilityProperty).UpdateTarget();
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

            if (ReferenceEquals(sender, ActualPlay) && !ReferenceEquals(Front.MyPlayer.CurrentlyPlaying, null))
                MyScroller.SelectedIndex = PlaylistFront.AllMusics.Index(Front.MyPlayer.CurrentlyPlaying);
        }
    }
}
