using Biblio;
using Stub;

namespace BackEnd
{
    public class UserDBFront
    {
        public static UserDB MyUserDB;
        public static void LoadUsers()
        {
            MyUserDB = ReferenceEquals(new PersistanceUsers().LoadUsers(), null) ? new StubUsers().LoadUsers() : new PersistanceUsers().LoadUsers();
        }

        public static void SaveUsers()
        {
            new PersistanceUsers().SaveUsers(MyUserDB);
        }
    }
}
