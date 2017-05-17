using Biblio;
using System;
using System.Net.Mail;
using System.Windows;

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

        private void Exit(object sender, RoutedEventArgs e) 
            => Close();

        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e) 
            => DragMove();

        private void Commit(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBase.IsAlreadyUsed(email.Text);
                Check?.Invoke(UserMaker.MakeUser(new MailAddress(email.Text, pseudo.Text), mdp.Password, null));
                Close();
            }
            catch (Exception ex)
            {
                wrong.Text = ex.Message;
            }
        }   
    }
}
