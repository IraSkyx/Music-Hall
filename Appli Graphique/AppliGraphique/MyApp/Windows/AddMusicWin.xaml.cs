using BackEnd;
using Biblio;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour AddMusicWin.xaml
    /// </summary>
    public partial class AddMusicWin : Window
    {
        private FileInfo infos;
        private OpenFileDialog Explo;          

        /// <summary>
        /// Instancie un AddMusicWin pour un ajout
        /// </summary>
        public AddMusicWin(FileInfo infos)
        {
            InitializeComponent();
            this.infos = infos;
            Titre.Text = infos.Name;
            Date.Text = infos.CreationTime.ToShortDateString();
        }

        /// <summary>
        /// Instancie un AddMusicWin pour une modification
        /// </summary>
        public AddMusicWin()
        {
            InitializeComponent();
            bigtitle.Text = "Modifier une musique";
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
        /// Permet au User d'ouvrir de rechercher une image
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void explorer(object sender, RoutedEventArgs e)
        {
            Explo = new OpenFileDialog();
            Explo.Filter = "Image Files(*.png, *.jpg, *.jpeg)| *.png; *.jpg; *.jpeg";
            if (Explo.ShowDialog() == true)
                Explorer.Content = Explo.SafeFileName;
        }

        /// <summary>
        /// Valide les modifications/l'ajout dans la base de données 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        /// <exception cref="NullReferenceException"> Si un champ est manquant (= null) </exception>
        private void Commit(object sender, RoutedEventArgs e)
        {
            IMusic music;
            Video.Text = (Video.Text).Replace(@"https://www.youtube.com/watch?v=", @"https://www.youtube.com/embed/");
            Video.Text = (Video.Text).Replace(@"https://youtu.be/", @"https://www.youtube.com/embed/");
            try
            {                
                if (ReferenceEquals((IMusic)DataContext, null)) //Ajout
                    music = MusicMaker.MakeMusic(Titre.Text, Artist.Text, Date.Text, Genre.Text, Infos.Text, new Uri(infos.FullName, UriKind.RelativeOrAbsolute), Video.Text, Explo.FileName, null);    
                else if(ReferenceEquals(Explo, null)) //Modif sans choix d'image
                    music = MusicMaker.MakeMusic(Titre.Text, Artist.Text, Date.Text, Genre.Text, Infos.Text, ((IMusic)DataContext).Audio, Video.Text, ((IMusic)DataContext).Image, ((IMusic)DataContext).Comments);        
                else //Modif avec choix d'image
                    music = MusicMaker.MakeMusic(Titre.Text, Artist.Text, Date.Text, Genre.Text, Infos.Text, ((IMusic)DataContext).Audio, Video.Text, Explo.FileName, ((IMusic)DataContext).Comments);

                if (PlaylistFront.AllMusics.PlaylistProperty.Count(x => x.Equals(music)) == 0)
                {
                    if (!ReferenceEquals((IMusic)DataContext, null))
                        DataContext = music;
                    else
                        PlaylistFront.AllMusics.PlaylistProperty.Add(music);
                    Close();
                }
                else if(music.Equals((IMusic)DataContext))
                    Close();
                else
                    MessageBox.Show("Musique déjà présente");
            }
            catch (NullReferenceException)
            {
                wrong.Visibility = Visibility.Visible;
            }
        }
    }
}
