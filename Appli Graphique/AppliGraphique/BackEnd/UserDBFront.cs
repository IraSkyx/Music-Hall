using Biblio;
using Stub;

namespace BackEnd
{
    public class UserDBFront
    {
        public static UserDB MyUserDB;

        public static void LoadUsers()
        {
            MyUserDB = ReferenceEquals(PersistanceUsers.LoadUsers(), null) ? StubUsers.LoadUsers() : PersistanceUsers.LoadUsers();
        }

        public static void SaveUsers()
        {
            PersistanceUsers.SaveUsers(MyUserDB);
        }
    }
}
