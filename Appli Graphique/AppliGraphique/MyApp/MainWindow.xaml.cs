using Biblio;
using Stub;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyApp.Properties;
using System.IO;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserDB AllUsers = ReferenceEquals(new PersistanceUsers().LoadUsers(), null) ? new StubUsers().LoadUsers() : new PersistanceUsers().LoadUsers();
        private CommentDB AllComment = new CommentDB();

        /// <summary>
        /// Instancie MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Settings.Default.Upgrade();
            if (Settings.Default.StayLogged)
                LogIn(AllUsers.Database.First(x => x.Address.Equals(Settings.Default.LastMail)));

            Panel.DataContext = MyPlayer.Player;
            MyScroller.DataContext = MyPlayer.Allmusics;                                            
        }

        /// <summary>
        /// Quitte le programme 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Exit(object sender, RoutedEventArgs e)
            => Close();

        /// <summary>
        /// Lance les méthodes suivantes lorsque l'appli est fermée 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void OnClose(object sender, EventArgs e)
        {
            new PersistanceMusics().SaveMusics(MyPlayer.Allmusics);
            new PersistanceUsers().SaveUsers(AllUsers);
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        /// <summary>
        /// Réduit la fenêtre
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Reduce(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;

        /// <summary>
        /// Déplace la fenêtre ou l'agrandit lors d'un double-clic
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                Increase(this, new RoutedEventArgs());
            DragMove();
        }

        /// <summary>
        /// Agrandit la fenêtre
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
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

        /// <summary>
        /// Ouvre la fenêtre de connexion ou déconnecte un User
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        /// <remarks>Le if correspond à l'ouverture  de la fenêtre de connexion</remarks>
        /// <remarks>Le else correspond à la gestion de la déconnexion</remarks>
        private void Connexion(object sender, RoutedEventArgs e)
        {
            if (ReferenceEquals(MyPlayer.Player.CurrentUser,null))
            {
                Connexion subWindow = new Connexion(AllUsers);
                subWindow.Check += value => LogIn(value);
                subWindow.ShowDialog();
            }
            else
            {
                Settings.Default.StayLogged = false;
                MyPlayer.Player.CurrentUser = null;
                MyPlaylist.DataContext = null;
            }
        }

        /// <summary>
        /// Connecte un User
        /// </summary>
        /// <param name="value"> L'User à connecter </param>
        private void LogIn(IUser value)
        {
            MyPlayer.Player.CurrentUser = value;
            MyPlaylist.DataContext = MyPlayer.Player.CurrentUser.Favorite;
            Settings.Default.LastMail = value.Address;           
            MyPlayer.Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }

        /// <summary>
        /// Ouvre la fenêtre d'inscription ou de profil
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        /// <remarks>Le if correspond à l'ouverture de la fenêtre d'inscription</remarks>
        /// <remarks>Le else correspond à l'ouverture de la fenêtre du profil</remarks>
        private void Inscription(object sender, RoutedEventArgs e)
        {
            if (!ReferenceEquals(MyPlayer.Player.CurrentUser, null))
            {
                Profil subWindow3 = new Profil(MyPlayer.Player.CurrentUser, AllUsers);
                subWindow3.Check += value =>
                {
                    AllUsers.Database.Add(value);
                    AllUsers.Database.Remove(AllUsers.Database.First(x => x.Equals(MyPlayer.Player.CurrentUser)));
                    LogIn(value);
                };
                subWindow3.ShowDialog();
            }
            else
            {
                Inscription subWindow2 = new Inscription(AllUsers);
                subWindow2.Check += value =>
                {
                    AllUsers.Database.Add(value);
                    LogIn(value);
                };
                subWindow2.ShowDialog();
            }
        }

        /// <summary>
        /// Met l'élement sélectionné de la Listview du haut à l'indice 1 et met à jour la vidéo de la sélection
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void MyScrollerSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tab.SelectedIndex = 1; 
            xSelection.YT.Browser.Navigate("https://www.youtube.com/v/" + new Uri(((IMusic)MyScroller.SelectedItem).Video, UriKind.RelativeOrAbsolute).Segments.Last().ToString());
        }

        /// <summary>
        /// Réinitialise l'indice de sélection de la ListView de recherche lorsqu'on clique sur un de ces éléments
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void MyTabSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab.SelectedIndex == 2)
            {
                xSearch.Search.SelectedIndex = -1;
                Tab.SelectedIndex = 2;
            }              
        }

        /// <summary>
        /// Permet de Scroller de gauche à droite et inversement 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        /// <remarks> Le if permet un scroll vers la gauche </remarks>
        /// <remarks> Le else permet un scroll vers la droite </remarks>
        private void MyScrollerWheeling(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                MyScroller.SelectedIndex = (MyScroller.SelectedIndex == 0) ? 0 : MyScroller.SelectedIndex - 1;                     
            else
                MyScroller.SelectedIndex = (MyScroller.SelectedIndex == MyPlayer.Allmusics.PlaylistProperty.Count-1) ? MyPlayer.Allmusics.PlaylistProperty.Count - 1 : MyScroller.SelectedIndex + 1;
            MyScroller.ScrollIntoView(MyPlayer.Allmusics.PlaylistProperty.ElementAt(MyScroller.SelectedIndex));
        }

        /// <summary>
        /// Permet de consulter une Music en cliquant sur un élément de sa playlist
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void ViewFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (!ReferenceEquals(MyPlayer.Player.CurrentUser,null) && !ReferenceEquals(MyPlaylist.SelectedItem,null))
                MyScroller.SelectedItem=((IMusic)MyPlaylist.SelectedItem);
        }

        /// <summary>
        /// Permet de lire une Music en double-cliquant sur un élément de sa playlist
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void ReadFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (!ReferenceEquals(MyPlayer.Player.CurrentUser, null) && !ReferenceEquals(MyPlaylist.SelectedItem, null) && ReferenceEquals(sender, MyPlaylist))
                MyPlayer.Player.Play((IMusic)MyPlaylist.SelectedItem);    
            else
                MyPlayer.Player.Play((IMusic)MyScroller.SelectedItem);
        }

        /// <summary>
        /// Permet de supprimer une Music en faisant un clic gauche sur un élément de sa playlist
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void DeleteFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (!ReferenceEquals(MyPlayer.Player.CurrentUser, null) && !ReferenceEquals(MyPlaylist.SelectedItem, null))
                MyPlayer.Player.CurrentUser.Favorite.PlaylistProperty.Remove((IMusic)MyPlaylist.SelectedItem);
            MyPlayer.Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }

        /// <summary>
        /// Permet d'ajouter une music via un Drag&Drop
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        public void DragAndDrop(object sender, DragEventArgs e)
        {
            FileInfo infos = new FileInfo(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
            if (infos.Extension == ".mp3")
            {
                AddMusicWin sub = new AddMusicWin(infos);
                sub.ShowDialog();
            }
        }

        /// <summary>
        /// Permet d'ouvrir le panneau d'administration
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void OpenPA(object sender, RoutedEventArgs e)
        {
            PA sub = new PA(MyPlayer.Allmusics);
            sub.ShowDialog();
        }
    }  
}
