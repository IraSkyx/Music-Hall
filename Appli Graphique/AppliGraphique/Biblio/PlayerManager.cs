using System.Linq;

namespace Biblio
{
    public class PlayerManager
    {
        public double time;
        public Player lecteur;
        public Playlist playlist;
        public bool Random;
        public bool IsPaused;

        public PlayerManager()
        {
            time = 0.00;
            IsPaused = true;
        }

        public void SetNext()
        {
            lecteur.SetPlay((playlist.playlist.IndexOf(lecteur.CurrentlyPlaying) == playlist.playlist.Count - 1) ? playlist.playlist.ElementAt(0) : playlist.playlist.ElementAt(playlist.playlist.IndexOf(lecteur.CurrentlyPlaying) + 1));
        }

        public void SetPrevious()
        {
            lecteur.SetPlay((playlist.playlist.IndexOf(lecteur.CurrentlyPlaying) == 0) ? playlist.playlist.ElementAt(playlist.playlist.Count - 1) : playlist.playlist.ElementAt(playlist.playlist.IndexOf(lecteur.CurrentlyPlaying) - 1));
        }

        public void SetRandom()
        {
            Random = !Random;
        }

        public void SetReplay()
        {
            lecteur.player.settings.setMode("Loop", !(lecteur.player.settings.getMode("Loop")));
        }

        public void PausePlay()
        {
            if (IsPaused)
            {
                lecteur.player.controls.currentPosition = time;
                lecteur.player.controls.play();
            }
            else
            {
                time = lecteur.player.controls.currentPosition;
                lecteur.player.controls.pause();
            }
        }

        public void SetVolume(int volume)
        {
            lecteur.player.settings.volume = volume;
        }
    }
}
