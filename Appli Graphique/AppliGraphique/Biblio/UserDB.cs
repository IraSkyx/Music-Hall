using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Biblio
{
    public class UserDB
    {
        public ObservableCollection<IUser> Database;

        public UserDB()
            => Database = new ObservableCollection<IUser>();

        public UserDB(ObservableCollection<IUser> Database)
            => this.Database = Database;

        public bool Exists(string address)
            => Database.Count(x => x.Infos.Address.Equals(address)) > 0;

        public bool Exists(string address, string password) 
            => Database.Count(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password)) > 0;

        public bool NotExists(string address, string pseudo, string password) 
            => UserMaker.IsValid(address) && pseudo.Length > 3 && password.Length > 3 && Database.Count(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password)) == 0;

        public IUser SearchFor(string mail, string password) 
            => Database.First(x => x.Infos.Address.Equals(mail) && x.Psswd.Equals(password));

        public override string ToString()
            => String.Join("", Database);
    }
}
