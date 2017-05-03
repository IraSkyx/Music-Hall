using Biblio;
using System.Windows;
using System.Windows.Controls;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Initialisation de tous les utilisateurs et de toutes les musiques
            AllUsers users = new AllUsers();
            users.All = LoadUsers.Load();
            AllMusic musics = new AllMusic();
            musics.All = LoadMusic.Load();
            scroller.DataContext = musics;
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
            Window1 subWindow = new Window1();
            subWindow.Show();
        }

        private void Reduce(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            Window2 subWindow2 = new Window2();
            subWindow2.Show();
        }

        private void Change(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //player.settings.volume = Convert.ToInt32(slider.Value);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}