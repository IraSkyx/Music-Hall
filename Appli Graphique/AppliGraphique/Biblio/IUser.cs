using System.Net.Mail;

namespace Biblio
{
    public interface IUser
    {
        string Address { get; set; }
        string Username { get; set; }
        string Psswd { get; set; }
        Playlist Favorite { get; set; }

        string ToString();
    }
}
