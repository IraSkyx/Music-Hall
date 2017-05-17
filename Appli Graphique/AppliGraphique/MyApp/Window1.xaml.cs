using Biblio;
using System;
using System.Windows;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private UserDB Database;
        public event Action<IUser> Check;

        public Window1(UserDB Database)
        {
            InitializeComponent();
            this.Database = Database;
        }

        private void Exit(object sender, RoutedEventArgs e) 
            => Close();

        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e) 
            => DragMove();

        private void Commit(object sender, RoutedEventArgs e)
        {
            if (Database.Exists(email.Text, passwd.Password))
            {
                Check?.Invoke(Database.SearchFor(email.Text, passwd.Password));
                Close();
            }
            else
                wrong.Visibility = Visibility.Visible;
        }
    }
}
