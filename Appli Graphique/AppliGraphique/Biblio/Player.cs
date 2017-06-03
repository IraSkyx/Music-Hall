using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace Biblio
{
    public class Player : MediaElement, INotifyPropertyChanged
    {        
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
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Instancie Player (+ appel Constructeur mère)
        /// </summary>
        public Player():base()
        {
            LoadedBehavior = MediaState.Manual;            
            UnloadedBehavior = MediaState.Stop;
        }

        /// <summary>
        /// Avance ou recule dans la lecture de la playlist
        /// </summary>
        /// <param name="Sens"> 1 pour Suivant, -1 pour Précédent </param>
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

        /// <summary>
        /// Lis la Music passée en paramètre
        /// </summary>
        /// <param name="currentlyPlaying"> Music souhaitant être lue </param>
        public void Play(IMusic currentlyPlaying)
        {
            CurrentlyPlaying = currentlyPlaying;      
            SetPlay();
        }

        /// <summary>
        /// Lis la Music venant d'être affectée à CurrentlyPlaying
        /// </summary>
        private void SetPlay()
        {
            if (CurrentlyPlaying != null)
            {
                Source = CurrentlyPlaying.Audio;
                Play();
                IsPlaying = true;
            }                                      
        }

        /// <summary>
        /// Change la position de la lecture par celle passée en paramètre
        /// </summary>
        /// <param name="NewPosition"> Nouvelle position dans la musique </param>
        public void ChangePosition(TimeSpan NewPosition)
        {
            Position = NewPosition;           
            Play();
            IsPlaying = true;
        }

        /// <summary>
        /// Avertit la vue du changement de valeur de la propriété
        /// </summary>
        /// <param name="Name"> Nom de la propriété modifiée </param>
        protected void OnPropertyChanged(string Name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
    }
}
