using System.Collections.ObjectModel;
using System.Linq;

namespace Biblio
{
    public class Playlist 
    {
        public ObservableCollection<Musique> playlist { get; set; }

        public Playlist()
        {
            playlist = new ObservableCollection<Musique>();
        }

        public void AddMusic(Musique music)
        {
            playlist.Add(music);
        }

        public void DeleteMusic(Musique music)
        {
            playlist.Remove(music);
        }

        public override string ToString()
        {
            return string.Join<Musique>("",playlist.ToArray());
        }
    }
}
