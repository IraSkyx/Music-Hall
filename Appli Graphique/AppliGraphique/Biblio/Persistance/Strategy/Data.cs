using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Biblio
{
    /// <summary>
    /// Stratégie de persistance
    /// </summary> 
    public abstract class Data
    {
        /// <summary>
        /// Chemin d'accès à AppData/MusicHall
        /// </summary> 
        static string MyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MusicHall");

        /// <summary>
        /// Définit le répertoire courant dans l'environnement %appdata%/MusicHall
        /// </summary>        
        /// <returns> La Playlist chargée contenant toutes les Musics </returns>
        public static void SetCurrentDirectory()
        {
            if (!Directory.Exists(MyPath))
                Directory.CreateDirectory(MyPath);

            Directory.SetCurrentDirectory(MyPath);
        }

        /// <summary>
        /// Lis le fichier de sauvegarde si il existe et de ce cas renvoit ce qui est lu
        /// </summary>    
        /// <param name="file"> Nom du fichier de désérialisation </param>
        /// <param name="Serializer"> Indique le contrat de données à respecter lors de la désérialisation </param>
        /// <returns> La Playlist chargée contenant toutes les Musics </returns>
        public static Serialize Deserialize(string file, DataContractSerializer Serializer)
        {
            if (!File.Exists(file))
                return null;
            using (XmlReader reader = XmlReader.Create(file))
                return (Serialize)Serializer.ReadObject(reader);
        }

        /// <summary>
        /// Créer un fichier de sauvegarde et sérialise l'objet 
        /// </summary>    
        /// <param name="file"> Nom du fichier de sérialisation </param>
        /// <param name="obj"> Objet à sérialiser </param>
        /// <param name="Serializer"> Indique le contrat de données à respecter lors de la sérialisation </param>
        public static void Serialize(string file, Serialize obj, DataContractSerializer Serializer)
        {
            using (XmlWriter writer = XmlWriter.Create(file, new XmlWriterSettings() { Indent = true }))
                Serializer.WriteObject(writer, obj);
        }
    }
}
