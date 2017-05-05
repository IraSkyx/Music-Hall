using System.Linq;
using System.Windows.Controls;

namespace Biblio
{
    public class Player
    {
        public MediaElement ElementPlayer;
        public Musique CurrentlyPlaying;
        public bool Loop;
        public bool RandomPlay;

        public Player()
        {
            ElementPlayer = new MediaElement();
            ElementPlayer.LoadedBehavior = MediaState.Manual;            
            ElementPlayer.UnloadedBehavior = MediaState.Stop;
            ElementPlayer.Volume = 0.5;
        }

        public bool GoToNextOrPrevious(User currentUser, int Sens)
        {
            if (CurrentlyPlaying == null)
                return false;
            int index = currentUser.Favorite.playlist.IndexOf(CurrentlyPlaying);
            CurrentlyPlaying = (Sens==1) ? (index + 1 == currentUser.Favorite.playlist.Count) ? currentUser.Favorite.playlist.ElementAt(0) : currentUser.Favorite.playlist.ElementAt(index + 1) : (index - 1 == -1) ? currentUser.Favorite.playlist.ElementAt(currentUser.Favorite.playlist.Count() - 1) : currentUser.Favorite.playlist.ElementAt(index - 1);
            return SetPlay();

        }

        public bool SetRandomPlay()
        {
            RandomPlay = !RandomPlay;
            return RandomPlay;
        }

        public bool SetLoop()
        {
            Loop = !Loop;
            return Loop;
        }

        public bool Play(Musique currentlyPlaying)
        {
            CurrentlyPlaying = currentlyPlaying;      
            return SetPlay();
        }

        private bool SetPlay()
        {
            if (CurrentlyPlaying.Audio != null)
            {
                ElementPlayer.Source = CurrentlyPlaying.Audio;
                ElementPlayer.Play();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
