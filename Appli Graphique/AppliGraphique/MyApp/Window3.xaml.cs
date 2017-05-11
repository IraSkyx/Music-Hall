using Biblio;
using System;
using System.Net.Mail;
using System.Windows;
using System.Windows.Media;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public event Action<User> Check;
        private User currentuser;
        private UserDB DataBase;

        public Window3(User currentuser, UserDB DataBase)
        {           
            this.currentuser = currentuser;
            this.DataBase = DataBase;
            InitializeComponent();           
            gridresources.DataContext = currentuser;
        }

        private void Exit(object sender, RoutedEventArgs e) 
            => Close();

        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e) 
            => DragMove();

        private void Commit(object sender, RoutedEventArgs e)
        {
            if (UserDB.IsValid(emailbox.Text) && (pseudobox.Text).Length > 3 && (mdpbox.Text).Length > 3 && !(DataBase.Exists(emailbox.Text)))
            {
                Check?.Invoke(new User(new MailAddress(emailbox.Text, pseudobox.Text), mdpbox.Text, currentuser.Favorite));
                Close();
            }                    
            else
            {
                SolidColorBrush red = new SolidColorBrush(Color.FromRgb(217, 30, 24));
                if (!UserDB.IsValid(emailbox.Text))
                {
                    email.Text = "Email invalide";
                    email.Foreground = red;
                }

                else if (DataBase.Exists(emailbox.Text))
                {
                    email.Text = "Email déjà utilisé";
                    email.Foreground = red;
                }

                if ((pseudo.Text).Length < 3)
                {
                    pseudo.Text = "4 caractères mini";
                    pseudo.Foreground = red;
                }

                if ((mdpbox.Text).Length < 3)
                {
                    mdp.Text = "4 caractères mini";
                    mdp.Foreground = red;
                }
            }
        }
    }
}
