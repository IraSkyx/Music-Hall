namespace Biblio
{
    /// <summary>
    /// Interface définissant les attributs essentiels d'un Commentaire
    /// </summary>
    public interface IComment
    {
        /// <summary>
        /// Nom de l'utilisateur ayant posté ce commentaire
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Note attribuée
        /// </summary>
        int Rate { get; set; }

        /// <summary>
        /// Commentaire donné
        /// </summary>
        string Com { get; set; }
    }
}