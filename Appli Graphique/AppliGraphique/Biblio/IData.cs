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

     public object Deserialize(string file, DataContractSerializer Serializer)
        {           
            if (!File.Exists(file))
                return null;
            using (XmlReader reader = XmlReader.Create(file))
            {
                 return Serializer.ReadObject(reader);    
            }
               
        }
       
        public void Serialize(ISerialize obj, DataContractSerializer Serializer)
        {
            using (XmlWriter writer = XmlWriter.Create("PersistanceUsers.xml", new XmlWriterSettings() { Indent = true }))
                Serializer.WriteObject(writer, obj);
        }
    }
}
