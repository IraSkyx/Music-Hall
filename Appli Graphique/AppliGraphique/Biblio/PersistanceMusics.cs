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
            SetCurrentDirectory(MyPath);            

            var Serializer = new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music) });

            if (!File.Exists("PersistanceMusics.xml"))
                return null;
            using (XmlReader reader = XmlReader.Create("PersistanceMusics.xml"))
                return (Playlist)Serializer.ReadObject(reader);
        }        

        public void SaveMusics(Playlist AllMusics)
        {
            SetCurrentDirectory(MyPath);

            var Serializer = new DataContractSerializer(typeof(Playlist), new Type[] { typeof(Music) });

            using (XmlWriter writer = XmlWriter.Create("PersistanceMusics.xml", new XmlWriterSettings() { Indent = true }))
                Serializer.WriteObject(writer, AllMusics);
        }

        public static void SetCurrentDirectory(string Path)
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            Directory.SetCurrentDirectory(Path);
        }
    }
}
