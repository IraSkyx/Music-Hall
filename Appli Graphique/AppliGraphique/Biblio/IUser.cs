using System.Net.Mail;

namespace Biblio
{
    public interface IUser
    {
        MailAddress Infos { get; set; }
        string Psswd { get; set; }
        Playlist Favorite { get; set; }

        string ToString();
    }
}
