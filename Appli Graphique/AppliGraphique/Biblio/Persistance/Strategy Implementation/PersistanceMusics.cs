using System;
using System.Runtime.Serialization;

namespace Biblio
{
    /// <summary>
    /// Implémentation de la stratégie de persistance pour les Musics
    /// </summary> 
    public class PersistanceMusics : Data
    {
        /// <summary>
        /// Mise en oeuvre de la persistance pour charger les Musics
        /// </summary>        
        /// <returns> La Playlist chargée contenant toutes les Musics </returns>
        public static Playlist LoadMusics()
        {
            SetCurrentDirectory();

            return (Playlist)Deserialize("PersistanceMusics.xml", new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music), typeof(Comment) }));
        }

        /// <summary>
        /// Mise en oeuvre de la persistance pour sérialiser les Musics
        /// </summary>        
        /// <param name="AllMusics"> Les Musics à sérialiser </param>
        public static void SaveMusics(Playlist AllMusics)
        {
            SetCurrentDirectory();
            Serialize("PersistanceMusics.xml", AllMusics, new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music), typeof(Comment) }));
        }
    }
}
