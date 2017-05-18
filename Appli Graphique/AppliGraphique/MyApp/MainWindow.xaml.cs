using Biblio;
using Stub;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       

        private UserDB Allusers = new StubUsers().LoadUsers();

        /// <summary>
        /// Instancie MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();       
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
        /// Réduit la fenêtre
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Reduce(object sender, RoutedEventArgs e) 
            => WindowState = WindowState.Minimized;

        /// <summary>
        /// Déplace la fenêtre ou l'agrandit si double-clic
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
        /// Agrandit/Réduit la fênetre
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
                Connexion subWindow = new Connexion(Allusers);
                subWindow.Check += value => LogIn(value);
                subWindow.Owner = Application.Current.MainWindow;
                subWindow.Show();
            }
            else
            {
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
            MyPlayer.Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget(); //Force le Binding à se refresh 
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
                Profil subWindow3 = new Profil(MyPlayer.Player.CurrentUser, Allusers);
                subWindow3.Check += value =>
                {
                    Allusers.Database.Add(value);
                    Allusers.Database.Remove(Allusers.Database.First(x => x.Equals(MyPlayer.Player.CurrentUser)));
                    LogIn(value);
                };
                subWindow3.Owner = Application.Current.MainWindow;
                subWindow3.Show();
            }
            else
            {
                Inscription subWindow2 = new Inscription(Allusers);
                subWindow2.Check += value =>
                {
                    Allusers.Database.Add(value);
                    LogIn(value);
                };
                subWindow2.Owner = Application.Current.MainWindow;
                subWindow2.Show();
            }
        }

        /// <summary>
        /// Met l'élement sélectionné de la Listview supérieure à l'indice 1 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void MyScrollerSelectionChanged(object sender, SelectionChangedEventArgs e)
            => Tab.SelectedIndex = 1;

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
            if (!ReferenceEquals(MyPlayer.Player.CurrentUser,null) && !ReferenceEquals(MyPlaylist.SelectedItem,null) && ReferenceEquals(sender, MyPlaylist))
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
            if (!ReferenceEquals(MyPlayer.Player.CurrentUser,null) && !ReferenceEquals(MyPlaylist.SelectedItem,null))
                MyPlayer.Player.CurrentUser.Favorite.PlaylistProperty.Remove((IMusic)MyPlaylist.SelectedItem);
            MyPlayer.Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }      
    }  
}
