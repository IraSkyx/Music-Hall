using Biblio;
using System;
using System.Linq;
using System.Windows;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public event Action <User> Check;
        AllUsers DataBase;

        public Window1(AllUsers DataBase)
        {
            InitializeComponent();
            this.DataBase = DataBase;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Reduce(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
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

        private void Commit(object sender, RoutedEventArgs e)
        {           
            var currentuser = DataBase.All.Where(x => x.Infos.Address.Equals(email.Text) && x.Psswd.Equals(passwd.Password));
            if (currentuser.Count()>0)
            {
                Check?.Invoke(currentuser.ElementAt(0));
                Close();
            }
            else
            {
                wrong.Visibility = Visibility.Visible;
            }
        }
    }
}
