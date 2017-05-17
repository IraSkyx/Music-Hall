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

        public void IsAlreadyUsed(string address)
        {
            if (Database.Count(x => x.Infos.Address.Equals(address)) > 0)
                throw new Exception("Email déjà utilisé");
        }

        public IUser LogIn(string address, string password)
        {
            if (Database.Count(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password)) == 0)
                throw new Exception("Mail ou mot de passe invalide");
            return Database.First(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password));
        }

        public override string ToString()
            => string.Join("", Database);
    }    
}
