using System.Net.Mail;

namespace Biblio
{

    internal class User : IUser
    {
        public MailAddress Infos { get; set; }
        public string Psswd { get; set; }
        public Playlist Favorite { get; set; }

        public User(MailAddress Infos, string Psswd, Playlist Favorite)
        {
            this.Infos = Infos;
            this.Psswd = Psswd;
            this.Favorite = Favorite;
        }

        public override string ToString() => $"{Infos}\n{Psswd}\n{Favorite}\n";
    }
}
