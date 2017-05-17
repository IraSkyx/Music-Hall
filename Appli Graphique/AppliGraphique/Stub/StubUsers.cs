using System;
using Biblio;
using System.Net.Mail;

namespace Stub
{
    public class StubUsers : IDataUsers
    {
        public UserDB LoadUsers()
        {
            UserDB liste = new UserDB();

            Playlist playlist = new Playlist();
            playlist.PlaylistProperty.Add(MusicMaker.MakeMusic("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "images/eFeder.jpg"));
            playlist.PlaylistProperty.Add(MusicMaker.MakeMusic("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "images/eJustLike.jpg"));

            liste.Database.Add(UserMaker.MakeUser(new MailAddress("toto@gmail.com", "toto"), "toto", playlist));

            return liste;
        }

        public void SaveUsers(UserDB DataBase)
        {
            throw new NotImplementedException();
        }
    }
}
