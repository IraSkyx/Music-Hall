using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

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

            Serialize(AllMusics, new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music) }));
        }
    }
}
