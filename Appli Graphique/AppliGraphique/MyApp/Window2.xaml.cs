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
        public event Action<IUser> Check;
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
            try
            {
                DataBase.Exists(email.Text);
                Check?.Invoke(UserMaker.MakeUser(new MailAddress(email.Text, pseudo.Text), mdp.Password, null));
                Close();
            }
            catch(Exception)
            {
                SolidColorBrush red = new SolidColorBrush(Color.FromRgb(217, 30, 24));
                if (!UserMaker.IsValid(email.Text))
                {
                    labelemail.Text = "Email invalide";
                    labelemail.Foreground = red;
                }
                else if (DataBase.Exists(email.Text))
                {
                    labelemail.Text = "Email déjà utilisé";
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
