using Biblio;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Musique> Result;
        private Player Player = new Player();
        private AllMusic musics;
        private AllUsers users;
        private User currentUser;

        public MainWindow()
        {
            InitializeComponent();

            //Initialisation Player
            FullPlayer.Children.Add(Player.ElementPlayer);
            Player.ElementPlayer.MediaOpened += MediaOpened;
            Player.ElementPlayer.MediaEnded += MediaEnded;

            //Initialisation de tous les utilisateurs et de toutes les musiques
            users = new AllUsers();
            users.All = LoadUsers.Load();
            musics = new AllMusic();
            musics.All = LoadMusic.Load();

            //Initialisation des DataContext  
            scroller.DataContext = musics;
            Search.ItemsSource = Result;
            FullPlayer.DataContext = Player.ElementPlayer;
            Currently.DataContext = Player.CurrentlyPlaying;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Reduce(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Increase(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                increase.Content = "⇱";
            }
            else
            {
                WindowState = WindowState.Maximized;
                increase.Content = "⇲";
            }
        }

        private void Connexion(object sender, RoutedEventArgs e)
        {
            if ((string)connexion.Content == "Connexion" && (string)inscription.Content == "Inscription")
            {
                Window1 subWindow = new Window1(users);
                subWindow.Check += value => LogIn(value);
                subWindow.Show();
            }
            else
            {
                currentUser = null;
                connexion.Content = "Connexion";
                connexion.ToolTip = "Se connecter";
                inscription.Content = "Inscription";
                inscription.ToolTip = "S'inscrire";
            }
        }

        private void LogIn(User value)
        {
            currentUser = value;
            connexion.Content = "Déconnexion";
            connexion.ToolTip = "Fermer la session";
            inscription.Content = currentUser.Infos.DisplayName;
            inscription.ToolTip = "Voir profil";
        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            if ((string)connexion.Content == "Déconnexion" && (string)inscription.Content == currentUser.Infos.DisplayName)
            {
                Window3 subWindow3 = new Window3(currentUser);
                subWindow3.Check += value =>
                {
                    users.All.Add(value);
                    users.All.Remove(currentUser);
                    LogIn(value);
                };
                subWindow3.Show();
            }
            else
            {
                Window2 subWindow2 = new Window2();
                subWindow2.Check += value =>
                {
                    users.All.Add(value);
                    LogIn(value);
                };
                subWindow2.Show();
            }
        }

        private void scroller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl.SelectedIndex = 1;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            scroller.SelectedIndex = musics.All.IndexOf((Musique)Search.SelectedItem);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Result = new ObservableCollection<Musique>(musics.All.Where(x => x.Title.Equals(Input.Text)));
            if (Result.Count > 0)
            {
                scroller.SelectedIndex = musics.All.IndexOf(Result.ElementAt(0));
                Input.Text = "";
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
                scrollviewer.LineLeft();
            else
                scrollviewer.LineRight();
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender == world)
                scroller.SelectedIndex = musics.All.IndexOf(new ObservableCollection<Musique>(musics.All.Where(x => x.Title.Equals("T1"))).ElementAt(0));
            if (sender == france)
                scroller.SelectedIndex = musics.All.IndexOf(new ObservableCollection<Musique>(musics.All.Where(x => x.Title.Equals("T5"))).ElementAt(0));
            if (sender == hall)
                scroller.SelectedIndex = musics.All.IndexOf(new ObservableCollection<Musique>(musics.All.Where(x => x.Title.Equals("T6"))).ElementAt(0));
            TabControl.SelectedIndex = 1;
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            PausePlay.Content = (Player.Play((Musique)scroller.SelectedItem)) ? "||" : "▶";
        }

        private void PausePlay_Click(object sender, RoutedEventArgs e)
        {
            if (Player.CurrentlyPlaying == null) return; //Si rien n'est en train d'être lu
            if ((string)PausePlay.Content == "||")
            {
                PausePlay.Content = "▶";
                Player.ElementPlayer.Pause();
            }
            else
            {
                PausePlay.Content = "||";
                Player.ElementPlayer.Play();
            }
        }

        private void Replay(object sender, RoutedEventArgs e)
        {
            replay.Foreground = (Player.SetRandomPlay()) ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void SetRandom(object sender, RoutedEventArgs e)
        {
            random.Foreground = (Player.SetRandomPlay()) ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if (currentUser == null || currentUser.Favorite == null)
                return;
            PausePlay.Content = (Player.GoToNextOrPrevious(currentUser, 1)) ? "||" : "▶";
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            if (currentUser == null || currentUser.Favorite == null)
                return;
            PausePlay.Content = (Player.GoToNextOrPrevious(currentUser, -1)) ? "||" : "▶";
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            if (Player.Loop) //Mode Replay activé
            {
                Player.ElementPlayer.Position = TimeSpan.Zero;
                Player.ElementPlayer.Play();
            }
            else if (Player.RandomPlay) //Mode Random activé
            {
                if (currentUser.Favorite == null)
                    PausePlay.Content = (Player.Play(musics.All.ElementAt(new Random().Next()))) ? "||" : "▶";
                else
                {
                    PausePlay.Content = (Player.Play(currentUser.Favorite.playlist.ElementAt(new Random().Next()))) ? "||" : "▶";
                }
            }
            else //Mode Replay & Random désactivé
            {
                Next(this, new RoutedEventArgs());
            }
        }
        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            SetDuration();
            image.Source = new BitmapImage(new Uri(Player.CurrentlyPlaying.Image));
            title.Text = Player.CurrentlyPlaying.Title;
            artist.Text = Player.CurrentlyPlaying.Artist;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(myEvent);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void myEvent(object sender, EventArgs e)
        {
            SetDuration();
        }

        private void SetDuration()
        {
            duration.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                Player.ElementPlayer.Position.Hours,
                Player.ElementPlayer.Position.Minutes,
                Player.ElementPlayer.Position.Seconds
                );
            Prog.Value = Player.ElementPlayer.Position.TotalSeconds;
            duration2.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                Player.ElementPlayer.NaturalDuration.TimeSpan.Hours,
                Player.ElementPlayer.NaturalDuration.TimeSpan.Minutes,
                Player.ElementPlayer.NaturalDuration.TimeSpan.Seconds
                );
        }
    }       
}