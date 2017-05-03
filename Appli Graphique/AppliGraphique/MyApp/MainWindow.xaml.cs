using Biblio;
using System;
using System.Linq;
using System.Collections.ObjectModel;
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
        ObservableCollection<Musique> Result;
        AllMusic musics;

        public MainWindow()
        {
            InitializeComponent();

            //Initialisation de tous les utilisateurs et de toutes les musiques
            AllUsers users = new AllUsers();
            users.All = LoadUsers.Load();
            musics = new AllMusic();
            musics.All = LoadMusic.Load();
            scroller.DataContext = musics;
            Search.ItemsSource = Result;
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
            if(Result.Count>0)
                scroller.SelectedIndex = musics.All.IndexOf(Result.ElementAt(0));
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
                scrollviewer.LineLeft();
            else
                scrollviewer.LineRight();
        }
    }
}