using System;
using System.Runtime.Serialization;

namespace Biblio
{
    public class PersistanceMusics : Data
    {
        public static Playlist LoadMusics()
        {
            SetCurrentDirectory();

            return (Playlist)Deserialize("PersistanceMusics.xml", new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music), typeof(Comment) }));
        }

        public static void SaveMusics(Playlist AllMusics)
        {
            SetCurrentDirectory();
            Serialize("PersistanceMusics.xml", AllMusics, new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music), typeof(Comment) }));
        }
    }
}
