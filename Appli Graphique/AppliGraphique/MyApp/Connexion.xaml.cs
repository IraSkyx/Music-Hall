using Biblio;
using System;
using System.Windows;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        private UserDB Database;
        public event Action<IUser> Check;

        /// <summary>
        /// Instancie Connexion
        /// </summary>
        public Connexion(UserDB Database)
        {
            InitializeComponent();
            this.Database = Database;
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
        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
                Check?.Invoke(Database.LogIn(email.Text, passwd.Password));
                Close();
            }
            catch (Exception ex)
            {
                wrong.Text = ex.Message;
            }
        }
    }
}
