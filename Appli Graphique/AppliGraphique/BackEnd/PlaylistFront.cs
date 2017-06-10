using Biblio;
using Stub;

namespace BackEnd
{
    /// <summary>
    /// Classe instanciant un Player pour que la vue y ait accès statiquement
    /// </summary>
    public class PlaylistFront
    {
        /// <summary>
        /// Contient toutes les Musics disponibles et les gèrent
        /// </summary>
        public static Playlist AllMusics;

        /// <summary>
        /// Désérialise/Charge un Player
        /// </summary>
        public static void LoadMusics()
        {
            AllMusics = ReferenceEquals(PersistanceMusics.LoadMusics(), null) ? StubMusics.LoadMusics() : PersistanceMusics.LoadMusics();
        }

        /// <summary>
        /// Sérialise un Player
        /// </summary>
        public static void SaveMusics()
        {
            PersistanceMusics.SaveMusics(AllMusics);
        }
    }
}
