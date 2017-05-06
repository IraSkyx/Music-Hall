using Biblio;
using System;
using System.Net.Mail;
using System.Windows;
using System.Windows.Media;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public event Action<User> Check;

        public Window2()
        {            
            InitializeComponent();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Reduce(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Commit(object sender, RoutedEventArgs e)
        {                   
            if (IsValid(email.Text) && (pseudo.Text).Length>3 && (mdp.Password).Length > 3)
            {
                Check?.Invoke(new User(new MailAddress(email.Text, pseudo.Text), mdp.Password, null));
                Close();
            }
            else
            {
                SolidColorBrush red = new SolidColorBrush(Color.FromRgb(217, 30, 24));
                if (!IsValid(email.Text))
                {
                    labelemail.Text = "Email invalide";
                    labelemail.Foreground = red;
                }
                    
                if ((pseudo.Text).Length < 3)
                {
                    labelpseudo.Text = "4 caractères mini";
                    labelpseudo.Foreground = red;
                }
                    
                if ((mdp.Password).Length < 3)
                {
                    labelmdp.Text = "4 caractères mini";
                    labelmdp.Foreground = red;
                }
            }
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
