using Biblio;
using MainTest;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Lecteur.xaml
    /// </summary>
    public partial class Lecteur : UserControl
    {
        public Player Player { get; set; } = new Player();
        public Playlist Allmusics = new Playlist();

        public Lecteur()
        {
            InitializeComponent();

            FullPlayer.Children.Add(Player);

            DataContext = Player;

            Player.MediaEnded += MediaEnded;

            Allmusics = Stub.LoadMusicsTest();
        }

        private void PausePlayClick(object sender, RoutedEventArgs e)
        {
            if (Player.IsPlaying)
            {
                Player.Pause();
                Player.IsPlaying = false;
            }
            else
            {
                Player.Play();
                Player.IsPlaying = true;
            }
        }

        private void Replay(object sender, RoutedEventArgs e) 
            => Player.SetLoop();

        private void Random(object sender, RoutedEventArgs e) 
            => Player.SetRandomPlay();

        private void NextAndPrevious(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender == next)
                    Player.GoToNextOrPrevious(1);
                else
                    Player.GoToNextOrPrevious(-1);
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            if (Player.Loop)
            {
                Player.Position = TimeSpan.Zero;
                Player.Play();
            }            
            else
                NextAndPrevious(this, new RoutedEventArgs());
        }

        private void ProgMouseClick(object sender, MouseButtonEventArgs e)
        {
            if (Player.Source != null && Player.NaturalDuration.HasTimeSpan)
            {
                Player.Position = new TimeSpan(0, 0, (int)((e.GetPosition(Prog).X / Prog.ActualWidth) * Prog.Maximum));
                Player.IsPlaying = true;
                Player.Play();
            }
        }

        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (Player.CurrentUser != null) //Si un user est connecté
            {
                if (Player.CurrentUser.Favorite == null) //Si l'utilisateur n'a pas de playlist
                    Player.CurrentUser.Favorite = new Playlist();
                if (Player.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals(Player.CurrentlyPlaying)) == 0) //Si pas déjà présente
                    Player.CurrentUser.Favorite.PlaylistProperty.Add(Player.CurrentlyPlaying);
            }               
        }
    }
}
