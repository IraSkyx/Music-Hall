using Biblio;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        private UserDB DataBase;

        public Window2(UserDB DataBase)
        {
            InitializeComponent();
            this.DataBase = DataBase;
        }

        private void Exit(object sender, RoutedEventArgs e) => Close();

        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();

        private void Commit(object sender, RoutedEventArgs e)
        {
            if (DataBase.NotExists(email.Text, pseudo.Text, mdp.Password))
            {
                Check?.Invoke(new User(new MailAddress(email.Text, pseudo.Text), mdp.Password, null));
                Close();
            }
            else
            {
                SolidColorBrush red = new SolidColorBrush(Color.FromRgb(217, 30, 24));
                if (!User.ValidMail(email.Text))
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
    }
}
