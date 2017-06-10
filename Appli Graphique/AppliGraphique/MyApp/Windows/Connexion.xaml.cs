using Biblio;
using System;
using System.Windows;
using System.Windows.Input;
using MyApp.Properties;
using BackEnd;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        /// <summary>
        /// Permet de renvoyer un IUser à la MainWindow
        /// </summary>
        public event Action<IUser> Check;

        /// <summary>
        /// Instancie Connexion
        /// </summary>
        public Connexion()
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
        /// <exception cref="Exception"> En cas d'erreur de connexion (Par exemple : ID/PW inexistants) levé par <code>LogIn()</code> </exception>
        private void Commit(object sender, RoutedEventArgs e)
        {
            try
            {                                
                Check?.Invoke(UserDBFront.MyUserDB.LogIn(email.Text, passwd.Password));
                if ((bool)StayLoggedIn.IsChecked)
                    Settings.Default.StayLogged = true;
                else
                    Settings.Default.StayLogged = false;              
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
            if (e.Key == Key.Enter)
                Commit(this, new RoutedEventArgs());
        }
    }
}
