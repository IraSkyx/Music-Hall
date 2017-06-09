using System;
using System.Collections.ObjectModel;

namespace Biblio
{
    public class MusicMaker
    {
        /// <summary>
        /// Fabrique une Music 
        /// </summary>
        /// <param name="Title"> Le Titre de la Music </param>
        /// <param name="Artist"> L'Artiste de la Music </param>
        /// <param name="Date"> La Date de la Music </param>
        /// <param name="Genre"> Le Genre de la Music </param>
        /// <param name="Infos"> Les Infos de la Music </param>
        /// <param name="Audio"> L'Audio de la Music </param>
        /// <param name="Video"> La Vidéo youtube de la Music </param>
        /// <param name="Image"> L'Image de la Music </param>
        /// <returns> La Music fabriquée </returns>

        public static IMusic MakeMusic(string Title, string Artist, string Date, string Genre, string Infos, Uri Audio, string Video, Uri Image, ObservableCollection<IComment> Comments)
           => new Music(Title, Artist, Date, Genre, Infos, Audio, GetVideoValid(Video) , Image, Comments);

        /// <summary>
        /// Transforme une URL youtube en ID Youtube
        /// </summary>
        /// <param name="Video"> string à modifier </param>
        /// <exception cref="FormatException"> En cas de mauvais lien </exception>
        /// <returns> la string modifiée </returns>
        private static string GetVideoValid(string Video)
        {
            Video = Video.Replace(@"https://www.youtube.com/watch?v=", String.Empty);
            Video = Video.Replace(@"https://www.youtube.com/embed/=", String.Empty);    
            Video = Video.Replace(@"https://youtu.be/", String.Empty);
            if (Video.Contains("www") || Video.Length != 11)
                throw new FormatException("URL vidéo non valide");
            else
                return Video;
        }
    }
}