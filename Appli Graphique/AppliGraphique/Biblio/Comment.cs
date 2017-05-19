using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Comment
    {
        public string Pseudo;
        public string Message;

        public Comment(string Pseudo,string Message)
        {
            this.Pseudo = Pseudo;
            this.Message = Message;
        }

        public override string ToString() => $"{Pseudo}\n{Message}\n";
        
    }
}
