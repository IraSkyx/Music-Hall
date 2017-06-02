using Biblio;
using Stub;

namespace BackEnd
{
    public class PlaylistFront
    {
        public static Playlist AllMusics;

        public static void LoadMusics()
        {
            AllMusics = ReferenceEquals(new PersistanceMusics().LoadMusics(), null) ? new StubMusics().LoadMusics() : new PersistanceMusics().LoadMusics();
        }

        public static void SaveMusics()
        {
            new PersistanceMusics().SaveMusics(AllMusics);
        }
    }
}
