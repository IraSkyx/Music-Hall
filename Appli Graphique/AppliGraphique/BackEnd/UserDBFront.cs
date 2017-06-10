using Biblio;
using Stub;

namespace BackEnd
{
    /// <summary>
    /// Classe instanciant une UserDB pour que la vue y ait accès statiquement
    /// </summary>
    public class UserDBFront
    {
        /// <summary>
        /// DataBase contenant tous les utilisateurs enregistrés
        /// </summary>
        public static UserDB MyUserDB;

        /// <summary>
        /// Désérialise/Charge une UserDB
        /// </summary>
        public static void LoadUsers()
        {
            MyUserDB = ReferenceEquals(PersistanceUsers.LoadUsers(), null) ? StubUsers.LoadUsers() : PersistanceUsers.LoadUsers();
        }

        /// <summary>
        /// Sérialise une UserDB
        /// </summary>
        public static void SaveUsers()
        {
            PersistanceUsers.SaveUsers(MyUserDB);
        }
    }
}
