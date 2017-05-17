using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Biblio
{
    public class UserDB
    {
        public ObservableCollection<IUser> Database;

        /// <summary>
        /// Instancie une UserDB 
        /// </summary>
        public UserDB()
        {
             Database = new ObservableCollection<IUser>();
        }

        /// <summary>
        /// Détermine si l'adresse est déjà utilisée
        /// </summary>
        /// <param name="address"> L'adresse entrée par l'User </param>
        /// <exception cref="Exception"> Lance une Exception si l'email est déjà utilisé </exception>
        public void IsAlreadyUsed(string address)
        {
            if (Database.Count(x => x.Infos.Address.Equals(address)) > 0)
                throw new Exception("Email déjà utilisé");
        }

        /// <summary>
        /// Détermine si l'User passé en paramètre remplit les critères pour se connecter
        /// </summary>
        /// <param name="address"> L'adresse et le mot de passe entrée par l'User </param>
        /// <returns> Retourne la première occurence matchant l'User passé en paramètre </returns>
        /// <exception cref="Exception"> Lance une Exception si l'email ou le mot de passe sont invalides </exception>
        public IUser LogIn(string address, string password)
        {
            if (Database.Count(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password)) == 0)
                throw new Exception("Mail ou mot de passe invalide");
            return Database.First(x => x.Infos.Address.Equals(address) && x.Psswd.Equals(password));
        }

        /// <summary>
        /// Fixe l'affichage de l'objet 
        /// </summary>
        /// <returns> Retourne la mise en forme de l'affichage </returns>
        public override string ToString()
            => string.Join("", Database);
    }    
}
