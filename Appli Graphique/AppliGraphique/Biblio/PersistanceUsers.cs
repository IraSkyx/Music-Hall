using System;
using System.Runtime.Serialization;

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

            Serialize("PersistanceUsers.xml", DataBase, new DataContractSerializer(typeof(UserDB), new Type[] { typeof(User), typeof(Playlist), typeof(Music) }));
        }
    }
}