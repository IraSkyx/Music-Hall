using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace Biblio
{
    public class Player : MediaElement, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IMusic _CurrentlyPlaying;
        public IMusic CurrentlyPlaying
        {
            get { return _CurrentlyPlaying; }
            set
            {
                _CurrentlyPlaying = value;
                OnPropertyChanged("CurrentlyPlaying");
            }
        }
        private IUser _CurrentUser;
        public IUser CurrentUser
        {
            get { return _CurrentUser; }
            set
            {
                _CurrentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }
        private bool _IsPlaying;
        public bool IsPlaying
        {
            get { return _IsPlaying; }
            set
            {
                _IsPlaying = value;
                OnPropertyChanged("IsPlaying");
            }
        }
        private bool _Loop;
        public bool Loop
        {
            get
            { return _Loop; }
            set
            {
                _Loop = value;
                _RandomPlay = _Loop ? false : _RandomPlay;
                OnPropertyChanged("Loop");
                OnPropertyChanged("RandomPlay");
            }
        }
        private bool _RandomPlay;
        public bool RandomPlay
        {
            get
            { return _RandomPlay; }
            set
            {
                _RandomPlay = value;
                _Loop = _RandomPlay ? false : _Loop;
                OnPropertyChanged("RandomPlay");
                OnPropertyChanged("Loop");
            }
        }

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public Player():base()
        {
            LoadedBehavior = MediaState.Manual;            
            UnloadedBehavior = MediaState.Stop;
        }

        public void GoToNextOrPrevious(int Sens)
        {
            try
            {
                int index = CurrentUser.Favorite.Index(CurrentlyPlaying);
                if (!RandomPlay)
                {                    
                    if (Sens == 1)
                        CurrentlyPlaying = (index + 1 == CurrentUser.Favorite.PlaylistProperty.Count()) ? CurrentUser.Favorite.PlaylistProperty.ElementAt(0) : CurrentUser.Favorite.PlaylistProperty.ElementAt(index + 1);
                    else
                        CurrentlyPlaying = (index - 1 == -1) ? CurrentUser.Favorite.PlaylistProperty.ElementAt(CurrentUser.Favorite.PlaylistProperty.Count() - 1) : CurrentUser.Favorite.PlaylistProperty.ElementAt(index - 1);
                }
                else
                     CurrentlyPlaying = CurrentUser.Favorite.PlaylistProperty.ElementAt(new Random().Next(0, CurrentUser.Favorite.PlaylistProperty.Count()));                    
                SetPlay();
            }
            catch (NullReferenceException)
            {
                throw;
            }            
        }

        public void Play(IMusic currentlyPlaying)
        {
            CurrentlyPlaying = currentlyPlaying;      
            SetPlay();
        }

        private void SetPlay()
        {
            if (CurrentlyPlaying != null)
            {
                Source = CurrentlyPlaying.Audio;
                Play();
                IsPlaying = true;
            }                                      
        }

        public void ChangePosition(TimeSpan NewPosition)
        {
            Position = NewPosition;           
            Play();
            IsPlaying = true;
        }
    }
}
