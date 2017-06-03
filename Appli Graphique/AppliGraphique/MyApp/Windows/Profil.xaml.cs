using BackEnd;
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

        /// <summary>
        /// Instancie Profil
        /// </summary>
        public Profil()
        {                    
            InitializeComponent();                       
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
                if(!((IUser)DataContext).Address.Equals(EmailBox.Text))
                    UserDBFront.MyUserDB.IsAlreadyUsed(EmailBox.Text);
                UserDB.IsValid(EmailBox.Text);
                Check?.Invoke(UserMaker.MakeUser(EmailBox.Text, PseudoBox.Text, MdpBox.Text, ((IUser)DataContext).Favorite));
                Close();
            }
            catch(Exception ex)
            {
                wrong.Text = ex.Message;
            }
        }

        /// <summary>
        /// Permet à l'utilisateur de valider en pressant la touche Entrée
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Commit(this, new RoutedEventArgs());
        }
    }
}
