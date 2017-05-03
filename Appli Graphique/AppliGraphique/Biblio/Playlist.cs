using System.Collections.ObjectModel;

namespace Biblio
{
    public class Playlist
    {
        private ObservableCollection<Musique> playlist;

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
            string a="";
            foreach(Musique music in playlist)
            {
                a += music.ToString();
            }
            return a;
        }
    }
}
