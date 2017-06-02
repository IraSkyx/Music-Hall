using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Biblio
{
    public abstract class IData
    {
        string MyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MusicHall");

        public void SetCurrentDirectory()
        {
            if (!Directory.Exists(MyPath))
                Directory.CreateDirectory(MyPath);

            Directory.SetCurrentDirectory(MyPath);
        }

        public ISerialize Deserialize(string file, DataContractSerializer Serializer)
        {
            if (!File.Exists(file))
                return null;
            using (XmlReader reader = XmlReader.Create(file))
                return (ISerialize)Serializer.ReadObject(reader);
        }

        public void Serialize(string file, ISerialize obj, DataContractSerializer Serializer)
        {
            using (XmlWriter writer = XmlWriter.Create(file, new XmlWriterSettings() { Indent = true }))
                Serializer.WriteObject(writer, obj);
        }
    }
}
