using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Biblio
{
    [DataContract]
    public class Playlist : Serialize
    {
        [DataMember]
        public ObservableCollection<IMusic> PlaylistProperty { get; set; }

        /// <summary>
        /// Instancie une Playlist
        /// </summary>
        public Playlist()
        { 
             PlaylistProperty = new ObservableCollection<IMusic>();
        }

        /// <summary>
        /// Instancie une Playlist à partir d'un IEnumerable (conversion implicite)
        /// </summary>
        /// <param name="mus"> Paramètre d'instanciation </param>
        public Playlist(IEnumerable<IMusic> Musics)
        {
            PlaylistProperty = new ObservableCollection<IMusic>(Musics); 
        }

        public void Add(IMusic Mus)
        {
            if (ReferenceEquals(PlaylistProperty, null))
                PlaylistProperty = new ObservableCollection<IMusic>();
            PlaylistProperty.Add(Mus);
        }

        /// <summary>
        /// Filtre les éléments de la ListView de recherche
        /// </summary>
        /// <param name="critere"> Critère de recherche </param>
        /// <param name="input"> Ce qu'a tapé l'utilisateur </param>
        /// <returns> Playlist matchant ce qu'à rentré l'utilisateur et son critère de recherche </returns>
        public Playlist Filter(string critere, string input)
        {
            switch (critere)
            {
                case "Par titre": return new Playlist(PlaylistProperty.Where(x => Regex.IsMatch(x.Title, input)));
                case "Par artiste": return new Playlist(PlaylistProperty.Where(x => Regex.IsMatch(x.Artist, input)));
                case "Par genre": return new Playlist(PlaylistProperty.Where(x => Regex.IsMatch(x.Genre, input)));
                case "Par date": return new Playlist(PlaylistProperty.Where(x => Regex.IsMatch(x.Date, input)));
                default: return null;
            }
        }

        /// <summary>
        /// Retourne l'indice de la première Music ayant ce titre
        /// </summary>
        /// <param name="title"> Titre à rechercher </param>
        /// <returns> L'indice de la première occurence matchant le Title </returns>
        public int SelectHomeMusic(string title) 
            => PlaylistProperty.IndexOf(PlaylistProperty.First(x => x.Title.Equals(title)));

        /// <summary>
        /// Retourne l'indice de la première Music matchant celle passée en paramètre
        /// </summary>
        /// <param name="currentlyPlaying"> Music à rechercher </param>
        /// <returns> L'indice de la première occurence matchant celle passée en paramètre </returns>
        public int Index(IMusic currentlyPlaying)
        {
            try
            {
                return PlaylistProperty.IndexOf(PlaylistProperty.First(x => x.Equals(currentlyPlaying)));
            }
            catch
            {
                throw new NullReferenceException();
            }            
        }

        /// <summary>
        /// Fixe l'affichage de l'objet 
        /// </summary>
        /// <returns> Retourne la mise en forme de l'affichage </returns>
        public override string ToString() 
            => string.Join<IMusic>("", PlaylistProperty.ToArray());
    }
}
