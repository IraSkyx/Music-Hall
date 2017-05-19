using Biblio;
using System;
using System.Windows;
using System.Windows.Input;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class Profil : Window
    {
        public event Action <IUser> Check;
        private IUser User;
        private UserDB DataBase;

        /// <summary>
        /// Instancie Profil
        /// </summary>
        public Profil(IUser User, UserDB DataBase)
        {           
            this.User = User;
            this.DataBase = DataBase;
            InitializeComponent();           
            DataContext = User;
        }

        /// <summary>
        /// Quitte le programme 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Exit(object sender, RoutedEventArgs e) 
            => Close();

        /// <summary>
        /// Déplace la fenêtre
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Drag(object sender, MouseButtonEventArgs e) 
            => DragMove();

        /// <summary>
        /// Renvoit un User via un event à la MainWindow si les informations sont correctes
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        /// <exception cref="Exception"> En cas d'erreur de connexion (Par exemple : ID/PW incorrectes ou déjà existants) levé par <code>IsAlreadyUsed()</code>, <code>MakeUser()</code> et <code>MailAddress()</code> </exception>
        private void Commit(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!User.Address.Equals(EmailBox.Text))
                    DataBase.IsAlreadyUsed(EmailBox.Text);
                UserDB.IsValid(EmailBox.Text);
                Check?.Invoke(UserMaker.MakeUser(EmailBox.Text, PseudoBox.Text, MdpBox.Text, User.Favorite));
                Close();
            }
            catch(Exception ex)
            {
                wrong.Text = ex.Message;
            }
        }
    }
}
