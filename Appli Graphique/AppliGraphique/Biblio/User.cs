using System;
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

        public static bool ValidMail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Infos}\n{Psswd}\n{Favorite}\n";
        }
    }
}
