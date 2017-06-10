using System;

namespace Biblio
{
    /// <summary>
    /// Créateur de Comment. Sert à instancier des Comments.
    /// </summary>
    public class CommentMaker
    {
        /// <summary>
        /// Fabrique un Comment 
        /// </summary>
        /// <param name="Username"> Le nom du User </param>
        /// <param name="Rate"> La Note attribué à la Music </param>
        /// <param name="Com"> Le Commentaire donné à la Music </param>
        /// <returns> Le Comment fabriqué </returns>
        public static IComment MakeComment(string Username, int Rate, string Com)
        {
            if (string.IsNullOrEmpty(Com))
                throw new FormatException("Veuillez indiquez un commentaire");
             return new Comment(Username, Rate, Com);
        }
    }
}