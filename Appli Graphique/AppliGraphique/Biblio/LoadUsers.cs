using System;
using System.Collections.ObjectModel;

namespace Biblio
{
    public class LoadUsers
    {
        public static ObservableCollection<User> Load()
        {
            ObservableCollection<User> liste = new ObservableCollection<User>();

            Playlist playlist = new Playlist();
            playlist.AddMusic(new Musique("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "images/eFeder.jpg"));
            playlist.AddMusic(new Musique("T1", "A1", "D1", "G1", "I1", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "images/eJustLike.jpg"));

            liste.Add(new User(new System.Net.Mail.MailAddress("toto@gmail.com","toto"), "toto", playlist));

            return liste;
        }
    }
}
