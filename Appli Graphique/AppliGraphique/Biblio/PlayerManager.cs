using System;
using System.Linq;
using WMPLib;

namespace Biblio
{
    public class PlayerManager
    {
        public double time;
        public Player lecteur;
        public Playlist playlist;
        public bool Random;
        public bool IsPaused;

        public PlayerManager(Player player, Playlist playlist)
        {
            lecteur = player;
            this.playlist = playlist;
            time = 0.00;
            IsPaused = false;
            Random = false;
            lecteur.player.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
        }

        private void Player_PlayStateChange(int NewState)
        {
            if (NewState == 8) {
                SetNext();
            }
        }

        public void SetNext()
        {
            if (Random)
            {
                SelectRandom();
            }
            else
            {
                lecteur.SetPlay((playlist.playlist.IndexOf(lecteur.CurrentlyPlaying) == playlist.playlist.Count - 1) ? playlist.playlist.ElementAt(0) : playlist.playlist.ElementAt(playlist.playlist.IndexOf(lecteur.CurrentlyPlaying) + 1));
            }
        }

        public void SetPrevious()
        {
            if (Random)
            {
                SelectRandom();
            }
            else
            {
                lecteur.SetPlay((playlist.playlist.IndexOf(lecteur.CurrentlyPlaying) == 0) ? playlist.playlist.ElementAt(playlist.playlist.Count - 1) : playlist.playlist.ElementAt(playlist.playlist.IndexOf(lecteur.CurrentlyPlaying) - 1));
            }
        }

        public void SelectRandom()
        {
            Random r = new Random();
            lecteur.SetPlay(playlist.playlist.ElementAt(r.Next(0, playlist.playlist.Count)));
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
                IsPaused = false;
            }
            else
            {
                time = lecteur.player.controls.currentPosition;
                lecteur.player.controls.pause();
                IsPaused = true;
            }
        }

        public void SetVolume(int volume)
        {
            lecteur.player.settings.volume = volume;
        }
    }
}
