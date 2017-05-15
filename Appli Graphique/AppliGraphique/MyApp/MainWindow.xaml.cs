using Biblio;
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
        private UserDB Allusers = Stub.LoadUsersTest();

        public MainWindow()
        {
            InitializeComponent();         

            //Initialisation des DataContext  
            Panel.DataContext = lecteur.Player;
            scroller.DataContext = lecteur.Allmusics;                                            
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            lecteur.Detail1.myThread.Abort();
            Close();
        }

        private void Reduce(object sender, RoutedEventArgs e) 
            => WindowState = WindowState.Minimized;

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                Increase(this, new RoutedEventArgs());
            DragMove();
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
                    Allusers.Database.Remove(Allusers.Database.First(x => x.Equals(lecteur.Player.CurrentUser)));
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

        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab.SelectedIndex == 2)
            {
                xSearch.Search.SelectedIndex = -1;
                Tab.SelectedIndex = 2;
            }              
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                scroller.SelectedIndex = (scroller.SelectedIndex == 0) ? 0 : scroller.SelectedIndex - 1;                     
            else
                scroller.SelectedIndex = (scroller.SelectedIndex == lecteur.Allmusics.PlaylistProperty.Count-1) ? lecteur.Allmusics.PlaylistProperty.Count - 1 : scroller.SelectedIndex + 1;
            scroller.ScrollIntoView(lecteur.Allmusics.PlaylistProperty.ElementAt(scroller.SelectedIndex));
        }

        private void ViewFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (lecteur.Player.CurrentUser != null && listBox.SelectedItem != null)
                scroller.SelectedItem=((Musique)listBox.SelectedItem);
        }

        private void ReadFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (lecteur.Player.CurrentUser != null && listBox.SelectedItem != null && ReferenceEquals(sender,listBox))
                lecteur.Player.Play((Musique)listBox.SelectedItem);    
            else
                lecteur.Player.Play((Musique)scroller.SelectedItem);
        }

        private void DeleteFromPlaylist(object sender, MouseButtonEventArgs e)
        {
            if (lecteur.Player.CurrentUser != null && listBox.SelectedItem != null)
                lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Remove((Musique)listBox.SelectedItem);
        }      
    }  
}
