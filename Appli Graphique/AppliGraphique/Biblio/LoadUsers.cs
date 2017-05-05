using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Biblio
{
    public class LoadUsers
    {
        public static ObservableCollection<User> Load()
        {
            ObservableCollection<User> liste = new ObservableCollection<User>();

            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "images");

            Playlist playlist = new Playlist();
            playlist.AddMusic(new Musique("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eFeder.jpg")));
            playlist.AddMusic(new Musique("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eJustLike.jpg")));

            liste.Add(new User(new System.Net.Mail.MailAddress("toto@gmail.com","toto"), "toto", playlist));

            return liste;
        }
    }
}
