using System;
using Biblio;

namespace Stub
{
    public class StubUsers
    {
        public UserDB LoadUsers()
        {
            UserDB liste = new UserDB();

            Playlist playlist = new Playlist();
            playlist.PlaylistProperty.Add(MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FvDk9paBf9I", "images/eFeder.jpg", null));
            playlist.PlaylistProperty.Add(MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/ktBMxkLUIwY", "images/eHolding.jpg", null));

            liste.Database.Add(UserMaker.MakeUser("toto@gmail.com", "toto", "toto", playlist));

            return liste;
        }

        public void SaveUsers(UserDB DataBase)
        {
            throw new NotImplementedException();
        }
    }
}
