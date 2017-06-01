using Biblio;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Windows.Threading;
using Stub;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Lecteur.xaml
    /// </summary>
    public partial class Lecteur : UserControl
    {
        public Player Player { get; set; } = new Player();
        public Playlist Allmusics { get; set; } = ReferenceEquals(new PersistanceMusics().LoadMusics(), null) ? new StubMusics().LoadMusics() : new PersistanceMusics().LoadMusics();
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

            FullPlayer.Children.Add(Player);

            FullPlayer.DataContext = Player;

            Player.MediaEnded += MediaEnded;
            Player.MediaOpened += MediaOpened;

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
            if (Player.NaturalDuration.HasTimeSpan)
            {
                Prog.Value = Player.Position.TotalSeconds;
                duration.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    Player.Position.Hours,
                    Player.Position.Minutes,
                    Player.Position.Seconds);
                duration2.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    Player.NaturalDuration.TimeSpan.Hours,
                    Player.NaturalDuration.TimeSpan.Minutes,
                    Player.NaturalDuration.TimeSpan.Seconds);
            }
        }

        /// <summary>
        /// Définit les valeurs de la ProgressBar et le DataContext la miniature
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            if (Player.NaturalDuration.HasTimeSpan)
            {
                Prog.Minimum = 0;
                Prog.Maximum = Player.NaturalDuration.TimeSpan.TotalSeconds;
                ActualPlay.DataContext = Player.CurrentlyPlaying;
            }       
        }

        /// <summary>
        /// Lis ou mets en pause le Player
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void PausePlayClick(object sender, RoutedEventArgs e)
        {
            if(!ReferenceEquals(Player.CurrentlyPlaying, null))
            {
                if (Player.IsPlaying)
                {
                    Player.Pause();
                    Player.IsPlaying = false;
                }
                else
                {
                    if (Player.NaturalDuration.TimeSpan.TotalSeconds == Player.Position.TotalSeconds)
                        Player.ChangePosition(TimeSpan.Zero);
                    else
                    {
                        Player.Play();
                        Player.IsPlaying = true;
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
            => Player.Loop=!Player.Loop;

        /// <summary>
        /// Active l'option lecture aléatoire
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Random(object sender, RoutedEventArgs e) 
            => Player.RandomPlay=!Player.RandomPlay;

        /// <summary>
        /// Désactive/active le son
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Mute(object sender, MouseButtonEventArgs e)
            => Player.Volume = Player.Volume == 0.00 ? 0.50 : 0.00;

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
                    Player.GoToNextOrPrevious(1);
                else
                    Player.GoToNextOrPrevious(-1);
            }
            catch (NullReferenceException)
            {
                Player.IsPlaying = false;
                Player.Pause();
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
            if (Player.Loop)
                Player.ChangePosition(TimeSpan.Zero);
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
            if (!ReferenceEquals(Player.Source,null) && Player.NaturalDuration.HasTimeSpan)
                Player.ChangePosition(new TimeSpan(0, 0, (int)((e.GetPosition(Prog).X / Prog.ActualWidth) * Prog.Maximum)));
        }

        /// <summary>
        /// Ajoute une Music à la playlist User (si connecté) tout en instanciant si nécessaire
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (!ReferenceEquals(Player.CurrentUser,null))
            {
                if (ReferenceEquals(Player.CurrentUser.Favorite,null))
                    Player.CurrentUser.Favorite = new Playlist();
                if (Player.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals(Player.CurrentlyPlaying)) == 0)
                    Player.CurrentUser.Favorite.PlaylistProperty.Add(Player.CurrentlyPlaying);
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
                MyScroller.SelectedIndex = Allmusics.Index((IMusic)MyPlaylist.SelectedItem);

            if (ReferenceEquals(sender, ActualPlay) && !ReferenceEquals(Player.CurrentlyPlaying, null))
                MyScroller.SelectedIndex = Allmusics.Index(Player.CurrentlyPlaying);
        }
    }
}
