using Biblio;
using System;
using System.Net.Mail;
using System.Windows;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public event Action<IUser> Check;
        public IUser User;
        private UserDB DataBase;

        public Window3(IUser User, UserDB DataBase)
        {           
            this.User = User;
            this.DataBase = DataBase;
            InitializeComponent();           
            DataContext = User;
        }

        private void Exit(object sender, RoutedEventArgs e) 
            => Close();

        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e) 
            => DragMove();

        private void Commit(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!User.Infos.Address.Equals(EmailBox.Text))
                    DataBase.IsAlreadyUsed(EmailBox.Text);
                Check?.Invoke(UserMaker.MakeUser(new MailAddress(EmailBox.Text, PseudoBox.Text), MdpBox.Text, User.Favorite));
                Close();
            }
            catch(Exception ex)
            {
                wrong.Text = ex.Message;
            }
        }
    }
}
