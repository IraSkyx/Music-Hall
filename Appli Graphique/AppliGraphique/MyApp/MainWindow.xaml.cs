using Biblio;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MainTest;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        private Playlist result = new Playlist();
        private UserDB Allusers = new UserDB();

        public MainWindow()
        {
            InitializeComponent();         

            //Persistance Loading
            //Allusers = LoadUsers.Load();
            //Allmusics = LoadMusics.Load();

            //UserControl events
            xSearch.Input.TextChanged += TextBox_TextChanged;
            xSearch.Search.SelectionChanged += Search_SelectionChanged;
            xSearch.Criterion.SelectionChanged += Criterion_SelectionChanged;

            xSelection.Add2.Click += AddToPlaylist;
            xSelection.PlaySong.Click += Play;

            xHome.world.MouseUp += Home_MouseUp;
            xHome.france.MouseUp += Home_MouseUp;
            xHome.hall.MouseUp += Home_MouseUp;

            lecteur.ActualPlay.MouseUp += SeeMusic;

            //Tests données
            Allusers = Stub.LoadUsersTest();

            //Initialisation des DataContext  
            Panel.DataContext = lecteur.Player;
            scroller.DataContext = lecteur.Allmusics;                                 
            xSearch.Search.DataContext = result;            
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            //Persistance Saving
            //SaveMusics.Save(Allmusics);
            //SaveUsers.Save(Allusers);
            Close();
        }

        private void Reduce(object sender, RoutedEventArgs e) 
            => WindowState = WindowState.Minimized;

        private void Drag(object sender, MouseButtonEventArgs e) 
            => DragMove();

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
            if (lecteur.Player.CurrentUser==null) //Fenêtre de connexion
            {
                Window1 subWindow = new Window1(Allusers);
                subWindow.Check += value => LogIn(value);
                subWindow.Owner = Application.Current.MainWindow;
                subWindow.Show();
            }
            else //Bouton déconnexion
            {
                lecteur.Player.CurrentUser = null;
                listBox.DataContext = null;
            }
        }

        private void LogIn(User value)
        {
            lecteur.Player.CurrentUser = value;
            listBox.DataContext = lecteur.Player.CurrentUser.Favorite;        
        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            if (lecteur.Player.CurrentUser != null) //Fenêtre de profil
            {
                Window3 subWindow3 = new Window3(lecteur.Player.CurrentUser, Allusers);
                subWindow3.Check += value =>
                {
                    Allusers.Database.Add(value);
                    Allusers.Database.Remove(lecteur.Player.CurrentUser);
                    LogIn(value);
                };
                subWindow3.Owner = Application.Current.MainWindow;
                subWindow3.Show();
            }
            else //Fenêtre d'inscription
            {
                Window2 subWindow2 = new Window2(Allusers);
                subWindow2.Check += value =>
                {
                    Allusers.Database.Add(value);
                    LogIn(value);
                };
                subWindow2.Owner = Application.Current.MainWindow;
                subWindow2.Show();
            }
        }

        private void scroller_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => Tab.SelectedIndex = 1;

        private void Search_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => scroller.SelectedItem = (Musique)xSearch.Search.SelectedItem;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(xSearch.Input.Text != String.Empty)
                xSearch.Search.DataContext = lecteur.Allmusics.Filter((string)((ComboBoxItem)xSearch.Criterion.SelectedItem).Content, xSearch.Input.Text);
        }

        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab.SelectedIndex == 2)
            {
                xSearch.Search.SelectedIndex = -1;
                Tab.SelectedIndex = 2;
            }              
        }

        private void Criterion_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => TextBox_TextChanged(this, new TextChangedEventArgs(e.RoutedEvent, UndoAction.None));

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                scroller.SelectedIndex = (scroller.SelectedIndex == 0) ? 0 : scroller.SelectedIndex - 1;                     
            else
                scroller.SelectedIndex = (scroller.SelectedIndex == lecteur.Allmusics.PlaylistProperty.Count-1) ? lecteur.Allmusics.PlaylistProperty.Count - 1 : scroller.SelectedIndex + 1;
            scroller.ScrollIntoView(lecteur.Allmusics.PlaylistProperty.ElementAt(scroller.SelectedIndex));
        }

        private void Home_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender == xHome.world)
                scroller.SelectedIndex = lecteur.Allmusics.SelectHomeMusic("T1");
            if (sender == xHome.france)
                scroller.SelectedIndex = lecteur.Allmusics.SelectHomeMusic("T5");
            if (sender == xHome.hall)
                scroller.SelectedIndex = lecteur.Allmusics.SelectHomeMusic("T6");
            Tab.SelectedIndex = 1;
        }

        private void Play(object sender, RoutedEventArgs e)
            => lecteur.Player.Play((Musique)scroller.SelectedItem);

        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (lecteur.Player.CurrentUser != null) //Si un user est connecté
                if (lecteur.Player.CurrentUser.Favorite!=null) //Si l'utilisateur a une playlist
                {
                    if (lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals((Musique)scroller.SelectedItem)) == 0) //Si la musique est déjà dans sa playlist
                        lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Add(lecteur.Add1 == sender ? lecteur.Player.CurrentlyPlaying : (Musique)scroller.SelectedItem);
                }
                else //Si l'utilisateur n'a pas de playlist
                {
                    lecteur.Player.CurrentUser.Favorite = new Playlist();
                    lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Add(lecteur.Add1 == sender ? lecteur.Player.CurrentlyPlaying : (Musique)scroller.SelectedItem);
                }
        }

        private void ReadFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (lecteur.Player.CurrentUser != null && listBox.SelectedItem != null)
                lecteur.Player.Play((Musique)listBox.SelectedItem);        
        }

        private void DeleteFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (lecteur.Player.CurrentUser != null && listBox.SelectedItem != null)
                lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Remove((Musique)listBox.SelectedItem);
        }

        private void SeeMusic(object sender, MouseButtonEventArgs e)
        {
            if (sender == listBox)
                scroller.SelectedIndex = lecteur.Allmusics.Index((Musique)listBox.SelectedItem);
            if (sender == lecteur.ActualPlay)
                scroller.SelectedIndex = lecteur.Allmusics.Index(lecteur.Player.CurrentlyPlaying);
            else if (listBox.SelectedItem!=null && sender==scroller)
                scroller.SelectedIndex = lecteur.Allmusics.Index((Musique)listBox.SelectedItem);
        }
    }  
}
