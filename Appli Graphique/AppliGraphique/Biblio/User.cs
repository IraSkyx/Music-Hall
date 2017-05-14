using System;
using System.Linq;
using System.Net.Mail;

namespace Biblio
{
  
    public class User
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

        public User()
        {
        }       

        public string HaveOrNot(Musique music)
        {
            return Favorite.PlaylistProperty.Count(x => x.Equals(music)) == 0 ? "✚" : "✓";
        } 

        public override string ToString() => $"{Infos}\n{Psswd}\n{Favorite}\n";
    }
}
