using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    [DataContract]
    public class CommentDB
    {
        [DataMember]
        public ObservableCollection<IComment> Database;

        public CommentDB()
        {
            Database = new ObservableCollection<IComment>();
        }

    }
}
