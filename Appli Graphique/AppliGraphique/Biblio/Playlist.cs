using System.Collections.Generic;

namespace Biblio
{
    public class Playlist
    {
        public List<Musique> playlist;

        public Playlist()
        {
            playlist = new List<Musique>();
        }

        public void AddMusic(Musique music)
        {
            playlist.Add(music);
        }

        public void DeleteMusic(Musique music)
        {
            playlist.Remove(music);
        }

    }
}
