using BackEnd;
using Biblio;
using System;
using System.Windows;
using System.Windows.Input;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    public partial class Inscription : Window
    {
        public event Action<IUser> Check;

        public Inscription()
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
        /// <exception cref="Exception"> En cas d'erreur d'inscription (Par exemple : ID/PW incorrectes ou déjà existants) levé par <code>IsAlreadyUsed()</code>, <code>MakeUser()</code> et <code>MailAddress()</code> </exception>
        private void Commit(object sender, RoutedEventArgs e)
        {
            try
            {
                UserDBFront.MyUserDB.IsAlreadyUsed(email.Text);
                UserDB.IsValid(email.Text);
                Check?.Invoke(UserMaker.MakeUser(email.Text, pseudo.Text, mdp.Password, null));
                Close();
            }
            catch (Exception ex)
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
            if(e.Key == Key.Enter)
                Commit(this, new RoutedEventArgs());
        }            
    }
}
