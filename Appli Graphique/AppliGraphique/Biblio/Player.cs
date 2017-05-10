using System.Linq;
using System.Windows.Controls;

namespace Biblio
{
    public class Player : MediaElement
    {
        public Musique CurrentlyPlaying { get; set; }
        public bool Loop { get; set; }
        public bool RandomPlay { get; set; }

        public Player():base()
        {
            LoadedBehavior = MediaState.Manual;            
            UnloadedBehavior = MediaState.Stop;
        }

        public bool GoToNextOrPrevious(User currentUser, int Sens)
        {
            if (CurrentlyPlaying == null)
                return false;
            int index = currentUser.Favorite.Index(CurrentlyPlaying);
            CurrentlyPlaying = (Sens==1) ? (index + 1 == currentUser.Favorite.PlaylistProperty.Count()) ? currentUser.Favorite.PlaylistProperty.ElementAt(0) : currentUser.Favorite.PlaylistProperty.ElementAt(index + 1) : (index - 1 == -1) ? currentUser.Favorite.PlaylistProperty.ElementAt(currentUser.Favorite.PlaylistProperty.Count() - 1) : currentUser.Favorite.PlaylistProperty.ElementAt(index - 1);
            return SetPlay();

        }

        public bool SetRandomPlay()
        {
            RandomPlay = !RandomPlay;
            if (RandomPlay)
                Loop = false;
            return RandomPlay;
        }

        public bool SetLoop()
        {
            Loop = !Loop;
            if (Loop)
                RandomPlay = false;
            return Loop;
        }

        public bool Play(Musique currentlyPlaying)
        {
            CurrentlyPlaying = currentlyPlaying;      
            return SetPlay();
        }

        private bool SetPlay()
        {
            if (CurrentlyPlaying != null)
            {
                if (CurrentlyPlaying.Audio != null)
                {
                    Source = CurrentlyPlaying.Audio;
                    Play();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;   
        }
    }
}
