namespace Biblio
{
    public class User
    {
        public string Pseudo;
        public string Email;
        public string Psswd;
        Playlist Favorite;

        public User(string Pseudo, string Email, string Psswd, Playlist Favorite)
        {
            this.Pseudo = Pseudo;
            this.Email = Email;
            this.Psswd = Psswd;
            this.Favorite = Favorite;
        }

    }
}
