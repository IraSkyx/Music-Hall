using Biblio;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyApp.Properties;
using System.IO;
using BackEnd;
using System.Windows.Forms;
using System.Drawing;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotifyIcon ToTaskBar = new NotifyIcon()
        {
            Icon = new Icon("images/NotifyIcon.ico"),
            Visible = true       
        };

        /// <summary>
        /// Instancie MainWindow
        /// </summary>
        public MainWindow()
        {
            UserDBFront.LoadUsers();
            PlaylistFront.LoadMusics();
            PlayerFront.LoadPlayer();

            InitializeComponent();

            ToTaskBar.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    Show();
                    WindowState = WindowState.Normal;
                };

            Settings.Default.Upgrade();
            if (Settings.Default.StayLogged)
                LogIn(UserDBFront.MyUserDB.Database.First(x => x.Address.Equals(Settings.Default.LastMail)));

            Panel.DataContext = PlayerFront.MyPlayer;
            MyScroller.DataContext = PlaylistFront.AllMusics;                                            
        }

        /// <summary>
        /// Cache la fenêtre à la minimisation, sinon la rend visible
        /// </summary>
        /// <param name="e"> Évènement déclenché par la vue </param>
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();
            base.OnStateChanged(e);
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
            UserDBFront.SaveUsers();
            PlaylistFront.SaveMusics();
            Settings.Default.Save();
            Settings.Default.Reload();
            ToTaskBar.Dispose();
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
            if (ReferenceEquals(PlayerFront.MyPlayer.CurrentUser, null))
            {
                Connexion subWindow = new Connexion();
                subWindow.Check += value => LogIn(value);
                subWindow.ShowDialog();
            }
            else
            {
                Settings.Default.StayLogged = false;
                PlayerFront.MyPlayer.CurrentUser = null;
                MyPlaylist.DataContext = null;
            }
        }

        /// <summary>
        /// Connecte un User
        /// </summary>
        /// <param name="value"> L'User à connecter </param>
        private void LogIn(IUser value)
        {
            PlayerFront.MyPlayer.CurrentUser = value;
            MyPlaylist.DataContext = PlayerFront.MyPlayer.CurrentUser.Favorite;
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
            if (!ReferenceEquals(PlayerFront.MyPlayer.CurrentUser, null))
            {
                Profil subWindow3 = new Profil()
                {
                    DataContext = PlayerFront.MyPlayer.CurrentUser
                };
                subWindow3.Check += value =>
                {
                    UserDBFront.MyUserDB.Database.Add(value);
                    UserDBFront.MyUserDB.Database.Remove(UserDBFront.MyUserDB.Database.First(x => x.Equals(PlayerFront.MyPlayer.CurrentUser)));
                    LogIn(value);
                };
                subWindow3.ShowDialog();
            }
            else
            {
                Inscription subWindow2 = new Inscription();
                subWindow2.Check += value =>
                {
                    UserDBFront.MyUserDB.Database.Add(value);
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
            if(!ReferenceEquals((IMusic)MyScroller.SelectedItem, null))
            {
                Tab.SelectedIndex = 1;
                xSelection.Browser.Navigate(new Uri("https://www.youtube.com/v/"+ ((IMusic)MyScroller.SelectedItem).Video, UriKind.RelativeOrAbsolute));
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
                MyScroller.SelectedIndex = (MyScroller.SelectedIndex == PlaylistFront.AllMusics.PlaylistProperty.Count-1) ? PlaylistFront.AllMusics.PlaylistProperty.Count - 1 : MyScroller.SelectedIndex + 1;
            MyScroller.ScrollIntoView(PlaylistFront.AllMusics.PlaylistProperty.ElementAt(MyScroller.SelectedIndex));
        }

        /// <summary>
        /// Permet de consulter une Music en cliquant sur un élément de sa playlist
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void ViewFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (!ReferenceEquals(PlayerFront.MyPlayer.CurrentUser,null) && !ReferenceEquals(MyPlaylist.SelectedItem,null))
                MyScroller.SelectedItem=((IMusic)MyPlaylist.SelectedItem);
        }

        /// <summary>
        /// Permet de lire une Music en double-cliquant sur un élément de sa playlist
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void ReadFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (!ReferenceEquals(PlayerFront.MyPlayer.CurrentUser, null) && !ReferenceEquals(MyPlaylist.SelectedItem, null) && ReferenceEquals(sender, MyPlaylist))
                PlayerFront.MyPlayer.Play((IMusic)MyPlaylist.SelectedItem);    
            else
                PlayerFront.MyPlayer.Play((IMusic)MyScroller.SelectedItem);
        }

        /// <summary>
        /// Permet de supprimer une Music en faisant un clic gauche sur un élément de sa playlist
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void DeleteFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (!ReferenceEquals(PlayerFront.MyPlayer.CurrentUser, null) && !ReferenceEquals(MyPlaylist.SelectedItem, null))
                PlayerFront.MyPlayer.CurrentUser.Favorite.PlaylistProperty.Remove((IMusic)MyPlaylist.SelectedItem);
            MyPlayer.Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
            MyPlayer.Add1.GetBindingExpression(VisibilityProperty).UpdateTarget();
        }

        /// <summary>
        /// Permet d'ajouter une music via un Drag&Drop
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        public void DragAndDrop(object sender, System.Windows.DragEventArgs e)
        {
            FileInfo infos = new FileInfo(((string[])e.Data.GetData(System.Windows.DataFormats.FileDrop))[0]);
            if (infos.Extension == ".mp3")
            {
                AddMusic sub = new AddMusic(infos);                
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
            PA sub = new PA();
            sub.ShowDialog();
        }

        /// <summary>
        /// Réinitialise la sélection de la ListView Search lors du passage à son onglet
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Tab.SelectedIndex == 2)
                xSearch.Search.SelectedItem = null;
        }
    }  
}
