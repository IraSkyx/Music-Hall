using System;

namespace Biblio
{
    /// <summary>
    /// Créateur de User. Sert à instancier des Users.
    /// </summary>
    public class UserMaker
    {
        /// <summary>
        /// Fabrique un User
        /// </summary>
        /// <param name="Address"> Email nécessaire à l'instanciation </param>
        /// <param name="Username"> Nom nécessaire à l'instanciation </param>
        /// <param name="Psswd"> Mot de passe nécessaire à l'instanciation </param>
        /// <param name="Favorite"> Playlist nécessaire à l'instanciation </param>
        /// <exception cref="FormatException"> Lance une FormatException si le Pseudo ou le mot de passe sont trop courts </exception>
        public static IUser MakeUser(string Address, string Username, string Psswd, Playlist Favorite)
        {
            if (Address.Length < 3)
                throw new FormatException("Pseudo trop court (3 caractères mini)");
            if (Psswd.Length < 3)
                throw new FormatException("Mot de passe trop court (3 caractères mini)");
            return new User(Address, Username, Psswd, Favorite);
        }
    }
}
