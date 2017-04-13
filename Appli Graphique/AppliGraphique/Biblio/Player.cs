using WMPLib;

namespace Biblio
{
    public class Player
    {
        public WindowsMediaPlayer player;
        public Musique CurrentlyPlaying;

        public Player()
        {
            player = new WindowsMediaPlayer();
        }

        public void SetPlay(Musique music)
        {
            player.URL = music.Audio;
            CurrentlyPlaying = music;
        }
    }
}
