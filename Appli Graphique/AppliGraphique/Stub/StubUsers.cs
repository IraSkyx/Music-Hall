using System;
using Biblio;
using System.Collections.ObjectModel;

namespace Stub
{
    public class StubUsers
    {
        public UserDB LoadUsers()
        {           
            Playlist playlist = new Playlist()
            {
                PlaylistProperty = new ObservableCollection<IMusic>()
                {
                    MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FvDk9paBf9I", "../images/eFeder.jpg", null),
                    MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/ktBMxkLUIwY", "../images/eHolding.jpg", null)
                }
                
            };

            return new UserDB()
            {
                Database = new ObservableCollection<IUser>()
                {
                    UserMaker.MakeUser("toto@gmail.com", "toto", "toto", playlist)
                }
            };
        }
    }
}
