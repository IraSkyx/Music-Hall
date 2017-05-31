using Biblio;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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
        public PA(Playlist AllMusics)
        {
            InitializeComponent();
            DataContext = AllMusics;
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
            => ((Lecteur)Application.Current.MainWindow.FindName("MyPlayer")).Allmusics.PlaylistProperty.Remove((IMusic)MyPlaylist.SelectedItem);

        /// <summary>
        /// Ajoute une music à la base de données
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void AddMusic(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Explo = new OpenFileDialog();
            Explo.Filter = "(.mp3)|*.mp3";
            if (Explo.ShowDialog() == true)
            {
                AddMusicWin sub = new AddMusicWin(new FileInfo(Explo.FileName));
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
            AddMusicWin sub = new AddMusicWin((IMusic)MyPlaylist.SelectedItem);
            sub.ShowDialog();
        }

        /// <summary>
        /// Permet d'ajouter une music via un Drag&Drop
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private new void Drop(object sender, DragEventArgs e)
            => ((MainWindow)Application.Current.MainWindow).DragAndDrop(this, e);
    }
}
