using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Biblio
{
    public abstract class Data
    {
        static string MyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MusicHall");

        public static void SetCurrentDirectory()
        {
            if (!Directory.Exists(MyPath))
                Directory.CreateDirectory(MyPath);

            Directory.SetCurrentDirectory(MyPath);
        }

        public static Serialize Deserialize(string file, DataContractSerializer Serializer)
        {
            if (!File.Exists(file))
                return null;
            using (XmlReader reader = XmlReader.Create(file))
                return (Serialize)Serializer.ReadObject(reader);
        }

        public static void Serialize(string file, Serialize obj, DataContractSerializer Serializer)
        {
            using (XmlWriter writer = XmlWriter.Create(file, new XmlWriterSettings() { Indent = true }))
                Serializer.WriteObject(writer, obj);
        }
    }
}
