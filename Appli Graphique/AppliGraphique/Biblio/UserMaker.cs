using System;
using System.Net.Mail;

namespace Biblio
{
    public class UserMaker
    {
        public static IUser MakeUser(MailAddress Infos, string Psswd, Playlist Favorite)
        {
            if (Infos.DisplayName.Length < 3 || Infos.Address.Length < 3 || Infos.DisplayName.Length < 3 || Psswd.Length < 3 || !IsValid(Infos.Address))
                throw new FormatException();
            return new User(Infos, Psswd, Favorite);
        }

        public static bool IsValid(string Mail)
        {
            try
            {
                if (ReferenceEquals(Mail, null) || Mail == String.Empty)
                    return false;
                MailAddress m = new MailAddress(Mail);
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
