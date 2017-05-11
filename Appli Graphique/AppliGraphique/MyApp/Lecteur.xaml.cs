using Biblio;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Lecteur.xaml
    /// </summary>
    public partial class Lecteur : UserControl
    {
        Player Player = new Player();
        public Lecteur()
        {
            InitializeComponent();
            Player.MediaOpened += MediaOpened;
            Player.MediaEnded += MediaEnded;
        }

        private void PausePlay_Click(object sender, RoutedEventArgs e)
        {
            if(Player.IsPlaying)
                Player.Pause();
            else
                Player.Play();
        }

        private void Replay(object sender, RoutedEventArgs e)
        {
            Player.SetLoop();
            Player.SetRandomPlay();
        }

        private void SetRandom(object sender, RoutedEventArgs e)
        {
            random.Foreground = (Player.SetRandomPlay()) ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
            replay.Foreground = (Player.Loop) ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if (currentUser == null || currentUser.Favorite == null)
                if (Player.RandomPlay)
                    Player.Play(Allmusics.PlaylistProperty.ElementAt(new Random().Next(0, Allmusics.PlaylistProperty.Count)));
                else
                    return;
            else
                Player.GoToNextOrPrevious(currentUser, 1);
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            if (currentUser == null || currentUser.Favorite == null)
                if (Player.RandomPlay)
                    Player.Play(Allmusics.PlaylistProperty.ElementAt(new Random().Next(0, Allmusics.PlaylistProperty.Count)));
                else
                    return;
            else
                Player.GoToNextOrPrevious(currentUser, -1);
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            if (Player.Loop) //Mode Replay activé
            {
                Player.Position = TimeSpan.Zero;
                Player.Play();
            }
            else if (Player.RandomPlay) //Mode Random activé
            {
                if (currentUser != null)
                {
                    if (currentUser.Favorite != null)
                        Player.Play(Allmusics.PlaylistProperty.ElementAt(new Random().Next(0, Allmusics.PlaylistProperty.Count)));
                    else
                        Player.Play(currentUser.Favorite.PlaylistProperty.ElementAt(new Random().Next(0, currentUser.Favorite.PlaylistProperty.Count)));
                }
                else
                    Player.Play(Allmusics.PlaylistProperty.ElementAt(new Random().Next()));
            }
            else //Mode Replay & Random désactivé
                Next(this, new RoutedEventArgs());
        }
        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            SetDuration();
            Add1.Visibility = Visibility.Visible;
            Prog.Maximum = Player.NaturalDuration.TimeSpan.TotalSeconds;
            ActualPlay.DataContext = Player.CurrentlyPlaying;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(myEvent);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void myEvent(object sender, EventArgs e) => SetDuration();

        private void SetDuration()
        {
            if (Player.Source != null && Player.NaturalDuration.HasTimeSpan)
            {
                duration.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    Player.Position.Hours,
                    Player.Position.Minutes,
                    Player.Position.Seconds
                    );
                Prog.Value = Player.Position.TotalSeconds;
                duration2.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    Player.NaturalDuration.TimeSpan.Hours,
                    Player.NaturalDuration.TimeSpan.Minutes,
                    Player.NaturalDuration.TimeSpan.Seconds
                    );
            }
        }

        private void ProgMouseClick(object sender, MouseButtonEventArgs e)
        {
            if (Player.Source != null && Player.NaturalDuration.HasTimeSpan)
            {
                Player.Position = new TimeSpan(0, 0, (int)((e.GetPosition(Prog).X / Prog.ActualWidth) * Prog.Maximum));
                Player.Play();
                PausePlay.Content = "||";
            }
        }
    }
}
