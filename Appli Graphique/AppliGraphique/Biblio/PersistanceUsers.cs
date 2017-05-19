using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Biblio
{
    public class PersistanceUsers : IDataUsers
    {
        string MyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MusicHall");

        public UserDB LoadUsers()
        {
            SetCurrentDirectory();

            var Serializer = new DataContractSerializer(typeof(UserDB), new Type[] { typeof(User), typeof(Playlist), typeof(Music) });

            if (!File.Exists("PersistanceUsers.xml"))
                return null;
            using (XmlReader reader = XmlReader.Create("PersistanceUsers.xml"))
                return (UserDB)Serializer.ReadObject(reader);
        }

        public void SaveUsers(UserDB DataBase)
        {
            SetCurrentDirectory();

            var Serializer = new DataContractSerializer(typeof(UserDB), new Type[] { typeof(User), typeof(Playlist), typeof(Music) });

            using (XmlWriter writer = XmlWriter.Create("PersistanceUsers.xml", new XmlWriterSettings() { Indent = true }))
                Serializer.WriteObject(writer, DataBase);
        }

        private void SetCurrentDirectory()
        {
            if (!Directory.Exists(MyPath))
                Directory.CreateDirectory(MyPath);

            Directory.SetCurrentDirectory(MyPath);
        }
    }
}
