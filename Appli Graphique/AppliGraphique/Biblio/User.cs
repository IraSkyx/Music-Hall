using System.Net.Mail;
using System.Runtime.Serialization;

namespace Biblio
{
    [DataContract]
    internal class User : IUser
    {
        [DataMember(Name = "Infos", Order = 0)]
        public MailAddress Infos { get; set; }

        [DataMember(Name = "Psswd", Order = 1)]
        public string Psswd { get; set; }

        [DataMember(Name = "Favorite", Order = 2)]
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
