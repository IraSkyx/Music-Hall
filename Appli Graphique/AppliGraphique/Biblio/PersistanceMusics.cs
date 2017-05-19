using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Biblio
{
    public class PersistanceMusics : IDataMusics
    {
        string MyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MusicHall");

        public Playlist LoadMusics()
        {
            SetCurrentDirectory();            

            var Serializer = new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music) });

            if (!File.Exists("PersistanceMusics.xml"))
                return null;
            using (XmlReader reader = XmlReader.Create("PersistanceMusics.xml"))
                return (Playlist)Serializer.ReadObject(reader);
        }        

        public void SaveMusics(Playlist AllMusics)
        {
            SetCurrentDirectory();

            var Serializer = new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music) });

            using (XmlWriter writer = XmlWriter.Create("PersistanceMusics.xml", new XmlWriterSettings() { Indent = true }))
                Serializer.WriteObject(writer, AllMusics);
        }

        private void SetCurrentDirectory()
        {
            if (!Directory.Exists(MyPath))
                Directory.CreateDirectory(MyPath);

            Directory.SetCurrentDirectory(MyPath);
        }
    }
}
