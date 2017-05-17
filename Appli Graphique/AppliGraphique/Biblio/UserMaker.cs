using System;
using System.Net.Mail;

namespace Biblio
{
    public class UserMaker
    {
        /// <summary>
        /// Fabrique un User
        /// </summary>
        /// <param name="Infos"> Infos nécessaires à l'instanciation </param>
        /// <param name="Psswd"> Mot de passe nécessaire à l'instanciation </param>
        /// <param name="Favorite"> Playlist nécessaires à l'instanciation </param>
        /// <exception cref="FormatException"> Lance une FormatException si le Pseudo ou le mot de passe sont trop courts </exception>
        public static IUser MakeUser(MailAddress Infos, string Psswd, Playlist Favorite)
        {
            if (Infos.DisplayName.Length < 3)
                throw new FormatException("Pseudo trop court (3 caractères mini)");
            if (Psswd.Length < 3)
                throw new FormatException("Mot de passe trop court (3 caractères mini)");
            return new User(Infos, Psswd, Favorite);
        }
    }
}
