using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Biblio
{
    public class PersistanceMusics : IDataMusics
    {
        public Playlist LoadMusics()
        {
            throw new NotImplementedException();
        }

        public void SaveMusics(Playlist AllMusics)
        {
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, "Persistance"));

            var Serializer = new DataContractSerializer(typeof(Playlist));

            using (XmlWriter writer = XmlWriter.Create("PersistanceMusics.xml", new XmlWriterSettings() { Indent = true }))
                Serializer.WriteObject(writer, AllMusics);
        }
    }
}
