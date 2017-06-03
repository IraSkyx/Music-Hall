using Biblio;
using Stub;

namespace BackEnd
{
    public class PlaylistFront
    {
        public static Playlist AllMusics;

        public static void LoadMusics()
        {
            AllMusics = ReferenceEquals(PersistanceMusics.LoadMusics(), null) ? StubMusics.LoadMusics() : PersistanceMusics.LoadMusics();
        }

        public static void SaveMusics()
        {
            PersistanceMusics.SaveMusics(AllMusics);
        }
    }
}
