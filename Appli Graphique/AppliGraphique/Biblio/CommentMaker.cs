using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class CommentMaker
    {
        public static IComment MakeComment(string Username, int Rate, string Com)
        {
            if (Com.Length == 0)
                throw new FormatException("Commentaire nul");
             return new Comment(Username,Rate, Com);
        }
    }
}
