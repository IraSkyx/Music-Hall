using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;

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

        public static bool IsValid(string emailaddress)
        {                          
            try
            {
                if (emailaddress == null || emailaddress == String.Empty)
                    return false;
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Exists(string address)
            => Database.Count(x => x.Infos.Address.Equals(address)) > 0;

        public bool Exists(string address, string password) 
            => Database.Count(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password)) > 0;

        public bool NotExists(string address, string pseudo, string password) 
            => IsValid(address) && pseudo.Length > 3 && password.Length > 3 && Database.Count(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password)) == 0;

        public User SearchFor(string mail, string password) 
            => Database.First(x => x.Infos.Address.Equals(mail) && x.Psswd.Equals(password));

        public override string ToString()
            => String.Join("", Database);
    }
}
