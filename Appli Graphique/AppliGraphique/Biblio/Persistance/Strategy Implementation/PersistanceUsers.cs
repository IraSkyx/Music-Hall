using System;
using System.Runtime.Serialization;

namespace Biblio
{
    /// <summary>
    /// Implémentation de la stratégie de persistance pour les Users
    /// </summary> 
    public class PersistanceUsers : Data
    {
        /// <summary>
        /// Mise en oeuvre de la persistance pour charger les Users
        /// </summary>        
        /// <returns> La DataBase de User chargée </returns>
        public static UserDB LoadUsers()
        {
            SetCurrentDirectory();

            return (UserDB)Deserialize("PersistanceUsers.xml", new DataContractSerializer(typeof(UserDB), new Type[] { typeof(User), typeof(Playlist), typeof(Music), typeof(Comment) }));
        }

        /// <summary>
        /// Mise en oeuvre de la persistance pour sérialiser les Users
        /// </summary>        
        /// <param name="DataBase"> La DataBase à sérialiser </param>
        public static void SaveUsers(UserDB DataBase)
        {
            SetCurrentDirectory();

            Serialize("PersistanceUsers.xml", DataBase, new DataContractSerializer(typeof(UserDB), new Type[] { typeof(User), typeof(Playlist), typeof(Music), typeof(Comment) }));
        }
    }
}