using Biblio;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using MainTest;

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
        private UserDB Allusers = new UserDB();
        private User currentUser;

        public MainWindow()
        {
            InitializeComponent();         

            //Persistance Loading
            //Allusers = LoadUsers.Load();
            //Allmusics = LoadMusics.Load();

            //UserControl events
            xSearch.Input.TextChanged += TextBox_TextChanged;
            xSearch.Search.SelectionChanged += Criterion_SelectionChanged;
            xSearch.Criterion.SelectionChanged += ListBox_SelectionChanged;

            xSelection.Add2.Click += AddToPlaylist;
            xSelection.PlaySong.Click += Play;

            xHome.world.MouseUp += Home_MouseUp;
            xHome.france.MouseUp += Home_MouseUp;
            xHome.hall.MouseUp += Home_MouseUp;

            //Tests données
            Allusers = Stub.LoadUsersTest();       
            Allmusics = Stub.LoadMusicsTest();

            //Initialisation des DataContext  
            scroller.DataContext = Allmusics;                                 
            xSearch.Search.DataContext = result;            
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            //Persistance Saving
            //SaveMusics.Save(Allmusics);
            //SaveUsers.Save(Allusers);
            Close();
        }

        private void Reduce(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

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
            if ((string)connexion.Content == "Connexion" && (string)inscription.Content == "Inscription") //Fenêtre de connexion
            {
                Window1 subWindow = new Window1(Allusers);
                subWindow.Check += value => LogIn(value);
                subWindow.Owner = Application.Current.MainWindow;
                subWindow.Show();
            }
            else //Bouton déconnexion
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
            listBox.DataContext = currentUser.Favorite;
            connexion.Content = "Déconnexion";
            connexion.ToolTip = "Fermer la session";
            inscription.Content = currentUser.Infos.DisplayName;
            inscription.ToolTip = "Voir profil";         
        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            if ((string)connexion.Content == "Déconnexion" && (string)inscription.Content == currentUser.Infos.DisplayName) //Fenêtre de profil
            {
                Window3 subWindow3 = new Window3(currentUser);
                subWindow3.Check += value =>
                {
                    Allusers.Database.Add(value);
                    Allusers.Database.Remove(currentUser);
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

        private void scroller_SelectionChanged(object sender, SelectionChangedEventArgs e) => Tab.SelectedIndex = 1;

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            scroller.SelectedIndex = Allmusics.PlaylistProperty.IndexOf((Musique)xSearch.Search.SelectedItem);
            xSearch.Input.Text = String.Empty;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (xSearch.Criterion.SelectedItem != null)
                xSearch.Search.DataContext = Allmusics.Filter((string)((ComboBoxItem)xSearch.Criterion.SelectedItem).Content, xSearch.Input.Text);
        }

        private void Criterion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (xSearch.Input.Text != String.Empty)
                TextBox_TextChanged(this, new TextChangedEventArgs(e.RoutedEvent, UndoAction.None));
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                scroller.SelectedIndex = (scroller.SelectedIndex == 0) ? 0 : scroller.SelectedIndex - 1;                     
            else
                scroller.SelectedIndex = (scroller.SelectedIndex == Allmusics.PlaylistProperty.Count-1) ? Allmusics.PlaylistProperty.Count - 1 : scroller.SelectedIndex + 1;
            scroller.ScrollIntoView(Allmusics.PlaylistProperty.ElementAt(scroller.SelectedIndex));
        }

        private void Home_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender == xHome.world)
                scroller.SelectedIndex = Allmusics.SelectHomeMusic("T1");
            if (sender == xHome.france)
                scroller.SelectedIndex = Allmusics.SelectHomeMusic("T5");
            if (sender == xHome.hall)
                scroller.SelectedIndex = Allmusics.SelectHomeMusic("T6");
            Tab.SelectedIndex = 1;
        }       

        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (currentUser != null) //Si un user est connecté
                if (currentUser.Favorite!=null) //Si l'utilisateur a une playlist
                {
                    if (currentUser.Favorite.PlaylistProperty.Count(x => x.Equals((Musique)scroller.SelectedItem)) == 0) //Si la musique est déjà dans sa playlist
                        currentUser.Favorite.PlaylistProperty.Add(lecteur.Add1 == sender ? Player.CurrentlyPlaying : (Musique)scroller.SelectedItem);
                }
                else //Si l'utilisateur n'a pas de playlist
                {
                    currentUser.Favorite = new Playlist();
                    currentUser.Favorite.PlaylistProperty.Add(lecteur.Add1 == sender ? Player.CurrentlyPlaying : (Musique)scroller.SelectedItem);
                }
        }

        private void ReadFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (currentUser != null && listBox.SelectedItem != null)
            {
                Player.Play((Musique)listBox.SelectedItem);
            }            
        }

        private void DeleteFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (currentUser != null && listBox.SelectedItem != null)
                    currentUser.Favorite.PlaylistProperty.Remove((Musique)listBox.SelectedItem);
        }

        private void SeeMusic(object sender, MouseButtonEventArgs e)
        {
            if (sender == listBox)
                scroller.SelectedIndex = Allmusics.Index((Musique)listBox.SelectedItem);
            if (sender == lecteur.ActualPlay)
                scroller.SelectedIndex = Allmusics.Index(Player.CurrentlyPlaying);
            else if (listBox.SelectedItem!=null && sender==scroller)
                scroller.SelectedIndex = Allmusics.Index((Musique)listBox.SelectedItem);
        }
    }  
}
