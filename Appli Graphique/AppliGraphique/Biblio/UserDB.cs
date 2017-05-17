using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

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
                throw new AlreadyUsedException("Email déjà utilisé");
        }

        public IUser CanLogIn(string address, string password)
        {
            if (Database.Count(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password)) > 0)
                throw new DoesntExistException("Mail ou mot de passe invalide");
            else
                return Database.First(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password));
        }

        public override string ToString()
            => String.Join("", Database);
    }    
}
