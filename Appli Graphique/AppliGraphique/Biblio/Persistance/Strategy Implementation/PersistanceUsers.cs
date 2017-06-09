using System;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace Biblio
{
    public class PersistanceUsers : Data
    {
        public static UserDB LoadUsers()
        {
            SetCurrentDirectory();

            return (UserDB)Deserialize("PersistanceUsers.xml", new DataContractSerializer(typeof(UserDB), new Type[] { typeof(User), typeof(Playlist), typeof(Music), typeof(Comment) }));
        }

        public static void SaveUsers(UserDB DataBase)
        {
            SetCurrentDirectory();

            Serialize("PersistanceUsers.xml", DataBase, new DataContractSerializer(typeof(UserDB), new Type[] { typeof(User), typeof(Playlist), typeof(Music), typeof(Comment) }));
        }
    }
}