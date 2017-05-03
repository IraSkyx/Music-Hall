namespace Biblio
{
  
    public class User
    {
       public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Psswd { get; set; }
        public Playlist Favorite { get; set; }

       
        public User(string Pseudo, string Email, string Psswd, Playlist Favorite)
        {
            this.Pseudo = Pseudo;
            this.Email = Email;
            this.Psswd = Psswd;
            this.Favorite = Favorite;
            
        }

        public override string ToString()
        {
            return $"{Pseudo}\n{Email}\n{Psswd}\n{Favorite}\n";
        }

    }
}
