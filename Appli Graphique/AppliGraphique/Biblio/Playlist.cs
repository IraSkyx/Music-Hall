using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Biblio
{
    public class Playlist
    {
        public ObservableCollection<IMusic> PlaylistProperty { get; set; }

        public Playlist()
            => PlaylistProperty = new ObservableCollection<IMusic>();

        public Playlist(IEnumerable<IMusic> mus)
            => PlaylistProperty=new ObservableCollection<IMusic>(mus); 

        public Playlist Filter(string critere, string input)
        {
            switch (critere)
            {
                case "Par titre": return new Playlist(PlaylistProperty.Where(x => Regex.IsMatch(x.Title, input)));
                case "Par artiste": return new Playlist(PlaylistProperty.Where(x => Regex.IsMatch(x.Artist, input)));
                case "Par genre": return new Playlist(PlaylistProperty.Where(x => Regex.IsMatch(x.Genre, input)));
                case "Par date": return new Playlist(PlaylistProperty.Where(x => Regex.IsMatch(x.Date, input)));
                default: return null;
            }
        }

        public int SelectHomeMusic(string title) 
            => PlaylistProperty.IndexOf(PlaylistProperty.First(x => x.Title.Equals(title)));

        public int Index(IMusic currentlyPlaying) 
            => PlaylistProperty.IndexOf(PlaylistProperty.First(x => x.Equals(currentlyPlaying)));

        public override string ToString() 
            => string.Join<IMusic>("", PlaylistProperty.ToArray());
    }
}
