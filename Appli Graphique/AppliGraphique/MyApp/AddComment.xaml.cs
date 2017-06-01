using Biblio;
using System;
using System.Windows;
using System.Windows.Input;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour AddComment.xaml
    /// </summary>
    public partial class AddComment : Window
    {

        private IUser User;
        private IMusic Music;

        /// <summary>
        /// Instancie un AddComment
        /// </summary>
        public AddComment(IUser User, IMusic Music)
        {
            InitializeComponent();
            this.User = User;
            this.Music = Music;
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
        /// Permet à l'utilisateur de valider en pressant la touche Entrée
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Commit(this, new RoutedEventArgs());
        }

        /// <summary>
        /// Renvoit un Comment à ajouter à la Music
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        /// <exception cref="FormatException"> En cas de commentaire vide </exception>
        private void Commit(object sender, RoutedEventArgs e)
        {
            try
            {               
                Music.AddComment(CommentMaker.MakeComment(User.Username, int.Parse(notation.Text), textcom.Text));
                Close();
            }
            catch (FormatException ex)
            {
                wrong.Text = ex.Message;
            }
        }
    }
}
