using Biblio;
using MainTest;
using System;
using static System.Console;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Lecteur.xaml
    /// </summary>
    public partial class Lecteur : UserControl
    {
        public Player Player { get; set; } = new Player();
        public Playlist Allmusics = Stub.LoadMusicsTest();
        public Thread myThread;

        public Lecteur()
        {
            InitializeComponent();

            FullPlayer.Children.Add(Player);

            FullPlayer.DataContext = Player;
            Detail.DataContext = Player;

            Player.MediaEnded += MediaEnded;
            Player.MediaOpened += MediaOpened;

            Update();
        }

        private void Update()
        {
            myThread = new Thread(() =>
            {
                while (Thread.CurrentThread.IsAlive)
                {
                    Application.Current.Dispatcher.Invoke(() => //Permet de modifier les Control appartenant au Thread GUI
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
                    });
                }         
            });
            myThread.Start();
        }

        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            if (Player.NaturalDuration.HasTimeSpan)
            {
                Prog.Minimum = 0;
                Prog.Maximum = Player.NaturalDuration.TimeSpan.TotalSeconds;
                ActualPlay.DataContext = Player.CurrentlyPlaying;
            }       
        }

        private void PausePlayClick(object sender, RoutedEventArgs e)
        {
            if(Player.CurrentlyPlaying != null)
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

        private void Replay(object sender, RoutedEventArgs e) 
            => Player.Loop=!Player.Loop;

        private void Random(object sender, RoutedEventArgs e) 
            => Player.RandomPlay=!Player.RandomPlay;

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
                Player.IsPlaying = false;
                Player.Pause();
                return;
            }
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            if (Player.Loop)
                Player.ChangePosition(TimeSpan.Zero);
            else
                NextAndPrevious(this, new RoutedEventArgs());
        }

        private void ProgMouseClick(object sender, MouseButtonEventArgs e)
        {
            if (Player.Source != null && Player.NaturalDuration.HasTimeSpan)
                Player.ChangePosition(new TimeSpan(0, 0, (int)((e.GetPosition(Prog).X / Prog.ActualWidth) * Prog.Maximum)));
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

        private void SeeMusic(object sender, MouseButtonEventArgs e)
        {
            if (ReferenceEquals(sender,((ListView)Application.Current.MainWindow.FindName("listBox"))))
                ((ListView)Application.Current.MainWindow.FindName("scroller")).SelectedIndex = Allmusics.Index((Musique)((ListView)Application.Current.MainWindow.FindName("listBox")).SelectedItem);

            if (ReferenceEquals(sender,ActualPlay) && Player.CurrentlyPlaying!=null)
                ((ListView)Application.Current.MainWindow.FindName("scroller")).SelectedIndex = Allmusics.Index(Player.CurrentlyPlaying);

            else if (((ListView)Application.Current.MainWindow.FindName("listBox")).SelectedItem != null && ReferenceEquals(sender,((ListView)Application.Current.MainWindow.FindName("scroller"))))
                ((ListView)Application.Current.MainWindow.FindName("scroller")).SelectedIndex = Allmusics.Index((Musique)((ListView)Application.Current.MainWindow.FindName("listBox")).SelectedItem);
        }
    }
}
