using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Biblio
{
    public class PersistanceUsers : IData
    {
        public UserDB LoadUsers()
        {
            SetCurrentDirectory();

            return (UserDB)Deserialize("PersistanceUsers.xml", new DataContractSerializer(typeof(UserDB), new Type[] { typeof(User), typeof(Playlist), typeof(Music) }));          
        }

        public void SaveUsers(UserDB DataBase)
        {
            SetCurrentDirectory();

            Serialize(DataBase, new DataContractSerializer(typeof(UserDB), new Type[] { typeof(User), typeof(Playlist), typeof(Music) }));
        }
    }
}
