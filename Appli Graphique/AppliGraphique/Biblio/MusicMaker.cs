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
        public static IMusic MakeMusic(string Title, string Artist, string Date, string Genre, string Infos, Uri Audio, string Video, string Image)
            => new Music(Title, Artist, Date, Genre, Infos, Audio, Video, Image);

        public static IMusic MakeMusic(string Title, string Artist, string Date, string Genre, string Infos, Uri Audio, string Video, string Image, ObservableCollection<Comment> Comments)
           => new Music(Title, Artist, Date, Genre, Infos, Audio, Video ,Image, Comments);
    }
}
