using System;
using System.Runtime.Serialization;

namespace Biblio
{
    public class PersistanceMusics : IData
    {
        public Playlist LoadMusics()
        {
            SetCurrentDirectory();

            return (Playlist)Deserialize("PersistanceMusics.xml", new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music) }));
        }

        public void SaveMusics(Playlist AllMusics)
        {
            SetCurrentDirectory();

            Serialize("PersistanceMusics.xml", AllMusics, new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music) }));
        }
    }
}
