using System.Collections.ObjectModel;

namespace Biblio
{
    public class AllUsers
    {
        public ObservableCollection<User> All { get; set; }

        public AllUsers()
        {
            All = new ObservableCollection<User>();
        }
    }
}
