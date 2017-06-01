using System.Collections.ObjectModel;
using System.Runtime.Serialization;

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

        public void Add(IComment Com)
        {
            if (ReferenceEquals(Database, null))
                Database = new ObservableCollection<IComment>();
            Database.Add(Com);
        }
    }
}
