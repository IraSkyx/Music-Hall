using System;
using System.Net.Mail;

namespace Biblio
{
    public class UserMaker
    {
        public static IUser MakeUser(MailAddress Infos, string Psswd, Playlist Favorite)
        {
            if (Infos.DisplayName.Length < 3 || Infos.DisplayName.Length < 3 || Psswd.Length < 3)
                throw new FormatException();
            return new User(Infos, Psswd, Favorite);
        }
        

    }
}
