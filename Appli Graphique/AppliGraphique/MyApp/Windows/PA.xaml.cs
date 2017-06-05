using BackEnd;
using Biblio;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour PA.xaml
    /// </summary>
    public partial class PA : Window
    {

        /// <summary>
        /// Instancie un PA
        /// </summary>
        public PA()
        {
            InitializeComponent();
            DataContext = PlaylistFront.AllMusics;
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
        /// Supprime une music de la base de données
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void DeleteMusic(object sender, RoutedEventArgs e)
            => PlaylistFront.AllMusics.PlaylistProperty.Remove((IMusic)MyPlaylist.SelectedItem);

        /// <summary>
        /// Ajoute une music à la base de données
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void AddMusic(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Explo = new OpenFileDialog()
            {
                Filter = "(.mp3)|*.mp3"
            };            
            if (Explo.ShowDialog() == true)
            {
                AddMusic sub = new AddMusic(new FileInfo(Explo.FileName));
                sub.ShowDialog();
            }  
        }

        /// <summary>
        /// Edite une music de la base de données
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void EditMusic(object sender, RoutedEventArgs e)
        {
            AddMusic sub = new AddMusic()
            {
                DataContext = (IMusic)MyPlaylist.SelectedItem
            };
            sub.ShowDialog();
        }
    }
}
