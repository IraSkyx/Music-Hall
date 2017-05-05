using Biblio;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Musique> Result;
        private AllMusic musics;
        private AllUsers users;
        private User currentUser;
        private Musique currentlyPlaying;
        private bool Loop=false;
        private bool RandomPlay=false;

        public MainWindow()
        {
            InitializeComponent();

            //Initialisation de tous les utilisateurs et de toutes les musiques
            users = new AllUsers();
            users.All = LoadUsers.Load();
            musics = new AllMusic();
            musics.All = LoadMusic.Load();

            //Initialisation des DataContext  
            scroller.DataContext = musics;
            Search.ItemsSource = Result;
            Progress.DataContext = Player;
            Player.DataContext = currentlyPlaying;

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
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
            if ((string)connexion.Content == "Connexion" && (string)inscription.Content== "Inscription")
            { 
                Window1 subWindow = new Window1(users);
                subWindow.Check += value =>
                {
                    LogIn(value);
                };
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

        private void Reduce(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
            Console.WriteLine(currentUser.Favorite.ToString());
        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            if((string)connexion.Content == "Déconnexion" && (string)inscription.Content == currentUser.Infos.DisplayName)
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
                Input.Text="";
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
            currentlyPlaying= (Musique)scroller.SelectedItem;
            Player.Source = ((Musique)scroller.SelectedItem).Audio;
            PausePlay.Content = "||";
            Player.Play();
        }

        private void PausePlay_Click(object sender, RoutedEventArgs e)
        {
            if (Player.Source==null) return; //Si rien n'est en train d'être lu
            if((string)PausePlay.Content == "||")
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
            if (Loop==false)
            {            
                replay.Foreground = new SolidColorBrush(Color.FromRgb(3, 166, 120));
                Loop = true;
            }               
            else
            {
                replay.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                Loop = false;
            }
        }

        private void SetRandom(object sender, RoutedEventArgs e)
        {           
            if (RandomPlay==false)
            {
                random.Foreground = new SolidColorBrush(Color.FromRgb(3, 166, 120));
                RandomPlay = true;
            }
            else
            {
                random.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                RandomPlay = false;
            }
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if (currentUser==null || currentUser.Favorite == null)
                return;
            var music = currentUser.Favorite.playlist.Where(x => x.Audio.Equals(Player.Source.ToString()));
            if (music.Count() == 0) //Est en train de lire une musique qui n'appartient pas à sa playlist 
                return;
            int Index = currentUser.Favorite.playlist.IndexOf(music.ElementAt(0));
            Player.Source = (Index + 1 == currentUser.Favorite.playlist.Count) ? currentUser.Favorite.playlist.ElementAt(0).Audio : currentUser.Favorite.playlist.ElementAt(Index+1).Audio;
            PausePlay.Content = "||";
            Player.Play();
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            if (currentUser==null || currentUser.Favorite == null)
                return;
            var music = currentUser.Favorite.playlist.Where(x => x.Audio.Equals(Player.Source.ToString()));
            if (music.Count() == 0) //Est en train de lire une musique qui n'appartient pas à sa playlist 
                return;
            int Index = currentUser.Favorite.playlist.IndexOf(music.ElementAt(0));
            Player.Source = (Index - 1 == -1) ? currentUser.Favorite.playlist.ElementAt(currentUser.Favorite.playlist.Count()-1).Audio : currentUser.Favorite.playlist.ElementAt(Index - 1).Audio;
            PausePlay.Content = "||";
            Player.Play();
        }

        private void Player_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (Loop) //Mode Replay activé
            {
                Player.Position = TimeSpan.Zero;
                Player.Play();
            }
            else if (RandomPlay) //Mode Random activé
            {
                if (currentUser.Favorite == null)
                {
                    Player.Source = musics.All.ElementAt(new Random().Next()).Audio;
                    PausePlay.Content = "||";
                    Player.Play();
                }
                else
                {
                    Player.Source = currentUser.Favorite.playlist.ElementAt(new Random().Next()).Audio;
                    PausePlay.Content = "||";
                    Player.Play();
                }               
            }
            else //Mode Replay & Random désactivé
            {
                Next(this, new RoutedEventArgs());
            }
        }
    }
}