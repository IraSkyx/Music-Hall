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

        public Window3(User currentuser)
        {           
            this.currentuser = currentuser;          
            InitializeComponent();
            gridresources.DataContext = currentuser;
        }

        private void Exit(object sender, RoutedEventArgs e) => Close();

        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();

        private void Commit(object sender, RoutedEventArgs e)
        {
            if (IsValid(emailbox.Text) && (pseudobox.Text).Length > 3 && (mdpbox.Text).Length > 3)
            {
                if (!(currentuser.Infos.Address.Equals(emailbox.Text)) || !(currentuser.Infos.DisplayName.Equals(pseudobox.Text)) || !(currentuser.Psswd.Equals(mdpbox.Text)))
                    Check?.Invoke(new User(new MailAddress(IsValid(emailbox.Text) ? emailbox.Text : currentuser.Infos.Address, (pseudobox.Text).Length > 3 ? pseudobox.Text : currentuser.Infos.DisplayName), (mdpbox.Text).Length > 3 ? mdpbox.Text : currentuser.Psswd, currentuser.Favorite));
                Close();
            }
            else
            {
                SolidColorBrush red = new SolidColorBrush(Color.FromRgb(217, 30, 24));
                if (!IsValid(email.Text))
                {
                    email.Text = "Email invalide";
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

        public bool IsValid(string emailaddress)
        {
            if (emailaddress == null || emailaddress == String.Empty)
                return false;
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
