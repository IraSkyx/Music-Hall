﻿using System.Runtime.Serialization;

namespace Biblio
{
    /// <summary>
    /// Classe définissant des structures de type "Utilisateur"
    /// </summary>
    [DataContract]
    internal class User : IUser
    {
        [DataMember(Name = "Address", Order = 0)]
        public string Address { get; set; }

        [DataMember(Name = "Username", Order = 1)]
        public string Username { get; set; }

        [DataMember(Name = "Psswd", Order = 2)]
        public string Psswd { get; set; }

        [DataMember(Name = "Favorite", Order = 3)]
        public Playlist Favorite { get; set; }

        /// <summary>
        /// Instancie une Music 
        /// </summary>
        /// <param name="Address"> Email du User </param>
        /// <param name="Username"> Nom du User </param>
        /// <param name="Psswd"> Mot de passe du User </param>
        /// <param name="Favorite"> Playlist du User </param>
        public User(string Address, string Username, string Psswd, Playlist Favorite)
        {
            this.Address = Address;
            this.Username = Username;
            this.Psswd = Psswd;
            this.Favorite = Favorite;
        }

        /// <summary>
        /// Fixe l'affichage de l'objet 
        /// </summary>
        /// <returns> Retourne la mise en forme de l'affichage </returns>
        public override string ToString() 
            => $"{Address}\n{Username}\n{Psswd}\n{Favorite}\n";
    }
}
