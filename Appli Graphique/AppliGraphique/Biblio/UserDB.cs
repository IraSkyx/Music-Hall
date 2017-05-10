using System.Collections.ObjectModel;
using System.Linq;

namespace Biblio
{
    public class UserDB
    {
        public ObservableCollection<User> Database;

        public UserDB()
        {
            Database = new ObservableCollection<User>();
        }

        public UserDB(ObservableCollection<User> Database)
        {
            this.Database = Database;
        }

        public bool Exists(string address, string password) 
            => Database.Count(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password)) > 0;

        public bool NotExists(string address, string pseudo, string password) 
            => User.ValidMail(address) && pseudo.Length > 3 && password.Length > 3 && Database.Count(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password)) == 0;

        public User SearchFor(string mail, string password) 
            => Database.First(x => x.Infos.Address.Equals(mail) && x.Psswd.Equals(password));
    }
}
