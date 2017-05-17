using System.Net.Mail;

namespace Biblio
{

    internal class User : IUser
    {
        public MailAddress Infos { get; set; }
        public string Psswd { get; set; }
        public Playlist Favorite { get; set; }

        /// <summary>
        /// Instancie une Music 
        /// </summary>
        /// <param name="Infos"> Les infos du User </param>
        /// <param name="Psswd"> Le Mot de passe du User </param>
        /// <param name="Favorite"> La Playlist du User </param>
        public User(MailAddress Infos, string Psswd, Playlist Favorite)
        {
            this.Infos = Infos;
            this.Psswd = Psswd;
            this.Favorite = Favorite;
        }

        /// <summary>
        /// Fixe l'affichage de l'objet 
        /// </summary>
        /// <returns> Retourne la mise en forme de l'affichage </returns>
        public override string ToString() => $"{Infos}\n{Psswd}\n{Favorite}\n";
    }
}
