using System;
using Biblio;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Stub
{
    public class StubUsers
    {
        public static UserDB LoadUsers()
        {           
            Playlist playlist = new Playlist()
            {
                PlaylistProperty = new ObservableCollection<IMusic>()
                {
                    MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "FvDk9paBf9I", new Uri("pack://application:,,,/Resources;Component/eFeder.jpg"), null),
                    MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "ktBMxkLUIwY", new Uri("pack://application:,,,/Resources;Component/eHolding.jpg"), null)
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
