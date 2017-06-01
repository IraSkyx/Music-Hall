using System;

namespace Biblio
{
    public class CommentMaker
    {
        public static IComment MakeComment(string Username, int Rate, string Com)
        {
            if (string.IsNullOrEmpty(Com))
                throw new FormatException("Veuillez indiquez un commentaire");
             return new Comment(Username, Rate, Com);
        }
    }
}