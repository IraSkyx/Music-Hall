using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;

namespace Biblio
{
    [DataContract]
    public class UserDB : ISerialize
    {
        [DataMember]
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
            if (Database.Count(x => x.Address.Equals(address)) > 0)
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
            if (Database.Count(x => x.Address.Equals(address) && x.Psswd.Equals(password)) == 0)
                throw new Exception("Mail ou mot de passe invalide");
            return Database.First(x => x.Address.Equals(address) && x.Psswd.Equals(password));
        }

        /// <summary>
        /// Détermine si une adresse est valide grâve à la FormatException de MailAddress
        /// </summary>
        /// <param name="Address"> L'adresse entrée par l'User </param>
        /// <exception cref="Exception"> Lance une Exception si l'email est invalide </exception>
        public static void IsValid(string Address)
        {
            MailAddress Add = new MailAddress(Address);
        }

        /// <summary>
        /// Fixe l'affichage de l'objet 
        /// </summary>
        /// <returns> Retourne la mise en forme de l'affichage </returns>
        public override string ToString()
            => string.Join("", Database);
    }    
}
