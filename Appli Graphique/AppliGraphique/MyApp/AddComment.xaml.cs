using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour AddComment.xaml
    /// </summary>
    public partial class AddComment : Window
    {
        public AddComment()
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
        /// Permet à l'utilisateur de valider en pressant la touche Entrée
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
                //Commit(this, new RoutedEventArgs());

            
        }

        private void validcomment_Click(object sender, RoutedEventArgs e)
        {
             try
            {
                
            //    Check?.Invoke(UserMaker.MakeUser(email.Text, pseudo.Text, mdp.Password, null)); username rate com
               
                Close();
            }
            catch (Exception ex)
            {
             //   wrong.Text = ex.Message;
            }
        }
    }
}
