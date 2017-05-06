using Biblio;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        private Player Player = new Player();
        private Playlist Allmusics = new Playlist();
        private Playlist result = new Playlist();
        private ObservableCollection<User> Allusers = new ObservableCollection<User>();
        private User currentUser;

        public MainWindow()
        {
            InitializeComponent();

            //Initialisation Player
            FullPlayer.Children.Add(Player);
            Player.MediaOpened += MediaOpened;
            Player.MediaEnded += MediaEnded;

            //Persistance
            Allusers = LoadUsers.Load();
            Allmusics = LoadMusic.Load();

            //Initialisation des DataContext  
            scroller.DataContext = Allmusics;                     
            FullPlayer.DataContext = Player;
            Search.DataContext = result;            
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
                Window1 subWindow = new Window1(Allusers);
                subWindow.Check += value => LogIn(value);
                subWindow.Owner = Application.Current.MainWindow;
                subWindow.Show();
            }
            else
            {
                currentUser = null;
                listBox.DataContext = null;
                connexion.Content = "Connexion";
                connexion.ToolTip = "Se connecter";
                inscription.Content = "Inscription";
                inscription.ToolTip = "S'inscrire";
            }
        }

        private void LogIn(User value)
        {
            currentUser = value;
            listBox.DataContext = currentUser;
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
                    Allusers.Add(value);
                    Allusers.Remove(currentUser);
                    LogIn(value);
                };
                subWindow3.Owner = Application.Current.MainWindow;
                subWindow3.Show();
            }
            else
            {
                Window2 subWindow2 = new Window2();
                subWindow2.Check += value =>
                {
                    Allusers.Add(value);
                    LogIn(value);
                };
                subWindow2.Owner = Application.Current.MainWindow;
                subWindow2.Show();
            }
        }

        private void scroller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl.SelectedIndex = 1;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            scroller.SelectedIndex = Allmusics.IndexOf((Musique)Search.SelectedItem);
            Input.Text = String.Empty;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (criterion.SelectedItem == bytitle)
                Search.DataContext=new Playlist(Allmusics.Where(x => Regex.IsMatch(x.Title, Input.Text)));
            else if (criterion.SelectedItem == byartist)
                Search.DataContext= new Playlist(Allmusics.Where(x => Regex.IsMatch(x.Artist, Input.Text)));
            else if (criterion.SelectedItem == bygenre)
                Search.DataContext = new Playlist(Allmusics.Where(x => Regex.IsMatch(x.Genre, Input.Text)));
            else if (criterion.SelectedItem == bydate)
                Search.DataContext = new Playlist(Allmusics.Where(x => Regex.IsMatch(x.Date, Input.Text)));
        }

        private void criterion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Input.Text != "")
                TextBox_TextChanged(this, new TextChangedEventArgs(e.RoutedEvent, UndoAction.None));
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                scroller.SelectedIndex = (scroller.SelectedIndex == 0) ? 0 : scroller.SelectedIndex - 1;                     
            else
                scroller.SelectedIndex = (scroller.SelectedIndex == Allmusics.Count-1) ? Allmusics.Count - 1 : scroller.SelectedIndex + 1;
            scroller.ScrollIntoView(Allmusics.ElementAt(scroller.SelectedIndex));
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender == world)
                scroller.SelectedIndex = Allmusics.IndexOf(new ObservableCollection<Musique>(Allmusics.Where(x => x.Title.Equals("T1"))).ElementAt(0));
            if (sender == france)
                scroller.SelectedIndex = Allmusics.IndexOf(new ObservableCollection<Musique>(Allmusics.Where(x => x.Title.Equals("T5"))).ElementAt(0));
            if (sender == hall)
                scroller.SelectedIndex = Allmusics.IndexOf(new ObservableCollection<Musique>(Allmusics.Where(x => x.Title.Equals("T6"))).ElementAt(0));
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
                Player.Pause();
            }
            else
            {
                PausePlay.Content = "||";
                Player.Play();
            }
        }

        private void Replay(object sender, RoutedEventArgs e)
        {
            replay.Foreground = (Player.SetLoop()) ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
            random.Foreground = (Player.RandomPlay) ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void SetRandom(object sender, RoutedEventArgs e)
        {           
            random.Foreground = (Player.SetRandomPlay()) ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
            replay.Foreground = (Player.Loop) ? new SolidColorBrush(Color.FromRgb(3, 166, 120)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if (currentUser == null || currentUser.Favorite == null)
            {
                PausePlay.Content = "▶";
                return;
            }
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
                Player.Position = TimeSpan.Zero;
                Player.Play();
            }
            else if (Player.RandomPlay) //Mode Random activé
            {
                if (currentUser != null)
                {
                    if (currentUser.Favorite != null)
                        PausePlay.Content = Player.Play(Allmusics.ElementAt(new Random().Next())) ? "||" : "▶";
                    else
                        PausePlay.Content = Player.Play(currentUser.Favorite.ElementAt(new Random().Next())) ? "||" : "▶";
                }
                else
                    PausePlay.Content = Player.Play(Allmusics.ElementAt(new Random().Next())) ? "||" : "▶";
            }
            else //Mode Replay & Random désactivé
            {
                Next(this, new RoutedEventArgs());
            }
        }
        private void MediaOpened(object sender, RoutedEventArgs e)
        {
            SetDuration();
            Add.Visibility = Visibility.Visible;
            Prog.Maximum = Player.NaturalDuration.TimeSpan.TotalSeconds;
            image.Source = new BitmapImage(new Uri(Player.CurrentlyPlaying.Image, UriKind.RelativeOrAbsolute));
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
                Prog.Value = (e.GetPosition(Prog).X / Prog.ActualWidth) * Prog.Maximum;
                Player.Position = new TimeSpan(0,0,(int)Prog.Value);
                Player.Play();
                PausePlay.Content = "||";
            }
        }

        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (currentUser != null) //Si un user est connecté
                if (currentUser.Favorite!=null) //Si l'utilisateur a une playlist
                {
                    if (currentUser.Favorite.Where(x => x.Title.Equals(((Musique)scroller.SelectedItem).Title)).Count() == 0) //Si la musique est déjà dans sa playlist
                        currentUser.Favorite.AddMusic((Musique)scroller.SelectedItem);
                }
                else //Si l'utilisateur n'a pas de playlist
                {
                    currentUser.Favorite = new Playlist();
                    currentUser.Favorite.AddMusic((Musique)scroller.SelectedItem);
                }
        }

        private void AddToPlaylist2(object sender, RoutedEventArgs e)
        {
            if (Player.CurrentlyPlaying != null && currentUser!=null) //Si une musique est en train d'être lu et qu'un user est connecté 
                currentUser.Favorite.AddMusic(Player.CurrentlyPlaying);
        }

        private void ReadFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (currentUser != null && listBox.SelectedItem != null)
            {
                Player.Play((Musique)listBox.SelectedItem);
                PausePlay.Content = "||";
            }            
        }

        private void DeleteFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (currentUser != null && listBox.SelectedItem != null)
                    currentUser.Favorite.DeleteMusic((Musique)listBox.SelectedItem);
        }

        private void SeeMusic(object sender, MouseButtonEventArgs e)
        {
            if (listBox.SelectedItem!=null)
                scroller.SelectedIndex = Allmusics.IndexOf(Allmusics.Where(x => x.Title.Equals(((Musique)listBox.SelectedItem).Title)).ElementAt(0));
        }
        private void SeeMusic2(object sender, MouseButtonEventArgs e)
        {
            scroller.SelectedIndex = Allmusics.IndexOf(Allmusics.Where(x => x.Title.Equals((Player.CurrentlyPlaying).Title)).ElementAt(0));
        }

    }  
}
