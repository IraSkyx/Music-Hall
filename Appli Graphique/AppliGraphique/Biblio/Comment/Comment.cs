﻿using System.Runtime.Serialization;

namespace Biblio
{
    /// <summary>
    /// Classe définissant des structures de type "Commentaire"
    /// </summary>
    [DataContract]
    internal class Comment : IComment
    {
        [DataMember(Name = "Username", Order = 0)]
        public string Username { get; set; }
        [DataMember(Name = "Rate", Order = 1)]
        public int Rate { get; set; }
        [DataMember(Name = "Com", Order = 2)]
        public string Com { get; set; }

        /// <summary>
        /// Constructeur de Comment
        /// </summary>
        internal Comment(string Username, int Rate, string Com)
        {
            this.Username = Username;
            this.Rate = Rate;
            this.Com = Com;
        }

        /// <summary>
        /// Fixe l'affichage de l'objet 
        /// </summary>
        /// <returns> Retourne la mise en forme de l'affichage </returns>
        public override string ToString() 
            => $"{Username}\n{Rate}\n{Com}\n";       
    }
}
