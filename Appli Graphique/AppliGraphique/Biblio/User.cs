using System.ComponentModel;
using System.Net.Mail;

namespace Biblio
{
  
    public class User
    {
        public MailAddress Infos { get; set; }
        public string Psswd { get; set; }
        public Playlist Favorite;

        public User(MailAddress Infos, string Psswd, Playlist Favorite)
        {
            this.Infos = Infos;
            this.Psswd = Psswd;
            this.Favorite = Favorite;            
        }     

        public override string ToString() => $"{Infos}\n{Psswd}\n{Favorite}\n";
    }
}
