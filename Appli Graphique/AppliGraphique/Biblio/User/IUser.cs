namespace Biblio
{
    /// <summary>
    /// Interface définissant les attributs essentiels d'un Utilisateur
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Adresse email de l'utilisateur
        /// </summary>
        string Address { get; set; }

        /// <summary>
        /// Nom de l'utilisateur
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        string Psswd { get; set; }

        /// <summary>
        /// Musiques favorites de l'utilisateur
        /// </summary>
        Playlist Favorite { get; set; }
    }
}
