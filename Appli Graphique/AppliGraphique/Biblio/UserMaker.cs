using System;
using System.Net.Mail;

namespace Biblio
{
    public class UserMaker
    {
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
