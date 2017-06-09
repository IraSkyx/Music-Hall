using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace Biblio
{
    [DataContract]
    internal class Music : IMusic, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _Title;
        [DataMember(Name = "Title", Order = 0)]
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _Artist;
        [DataMember(Name = "Artist", Order = 1)]
        public string Artist
        {
            get
            {
                return _Artist;
            }
            set
            {
                _Artist = value;
                OnPropertyChanged("Artist");
            }
        }

        private string _Date;
        [DataMember(Name = "Date", Order = 2)]
        public string Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
                OnPropertyChanged("Date");
            }
        }

        private string _Genre;
        [DataMember(Name = "Genre", Order = 3)]
        public string Genre
        {
            get
            {
                return _Genre;
            }
            set
            {
                _Genre = value;
                OnPropertyChanged("Genre");
            }
        }

        private string _Infos;
        [DataMember(Name = "Infos", Order = 4)]
        public string Infos
        {
            get
            {
                return _Infos;
            }
            set
            {
                _Infos = value;
                OnPropertyChanged("Infos");
            }
        }

        private Uri _Audio;
        [DataMember(Name = "Audio", Order = 5)]
        public Uri Audio
        {
            get
            {
                return _Audio;
            }
            set
            {
                _Audio = value;
                OnPropertyChanged("Audio");
            }
        }

        private string _Video;
        [DataMember(Name = "Video", Order = 6)]
        public string Video
        {
            get
            {
                return _Video;
            }
            set
            {
                _Video = value;
                OnPropertyChanged("Video");
            }
        }

        private Uri _Image;
        [DataMember(Name = "Image", Order = 7)]
        public Uri Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
                OnPropertyChanged("Image");
            }
        }

        private ObservableCollection<IComment> _Comments;
        [DataMember(Name = "Comments", Order = 8)]
        public ObservableCollection<IComment> Comments
        {
            get
            {
                return _Comments;
            }
            set
            {
                _Comments = value;
                OnPropertyChanged("Comments");
            }
        }

        protected void OnPropertyChanged(string Name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));

        /// <summary>
        /// Constructeur de Music
        /// </summary>
        internal Music(string Title, string Artist, string Date, string Genre, string Infos, Uri Audio, string Video, Uri Image, ObservableCollection<IComment> Comments)
        {
            this.Title = Title;
            this.Artist = Artist;
            this.Date = Date;
            this.Genre = Genre;
            this.Infos = Infos;
            this.Audio = Audio;
            this.Video = Video;
            this.Image = Image;
            this.Comments = Comments;
        }

        /// <summary>
        /// Ajoute un Comment
        /// </summary>
        /// <param name="Com"> Comment à ajouter </param>
        public void AddComment(IComment Com)
        {
            if (ReferenceEquals(Comments, null))
                Comments = new ObservableCollection<IComment>();
            Comments.Add(Com);
            OnPropertyChanged("Comments");
        }

        /// <summary>
        /// Vérifie que l'object "o" est égal à cette musique ou pas 
        /// </summary>
        /// <param name="o"> Le second object qui sera comparé à cette Music </param>
        /// <returns>true si égaux, false sinon </returns>
        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, null))
                return false;

            if (ReferenceEquals(this, o))
                return true;

            if (GetType() != o.GetType())
                return false;

            return Equals(o as IMusic);
        }

        /// <summary>
        /// Vérifie si cette Music est égale à l'autre Music
        /// </summary>
        /// <param name="other"> L'autre musique qui sera comparé à cette Music </param>
        /// <returns>true si égaux, false sinon </returns>
        public bool Equals(IMusic other) 
            => (Title.Equals(other.Title) && Artist.Equals(other.Artist) && Date.Equals(other.Date) && Genre.Equals(other.Genre) && Infos.Equals(other.Infos) && Audio.ToString().Equals(other.Audio.ToString()) && Video.Equals(other.Video));

        /// <summary>
        /// Fixe le HashCode de l'objet
        /// </summary>
        /// <returns>Un entier HashCode aléatoire </returns>
        public override int GetHashCode()
            => Title.Length * 31 + Title.GetHashCode();

        /// <summary>
        /// Fixe l'affichage de l'objet 
        /// </summary>
        /// <returns> Retourne la mise en forme de l'affichage </returns>
        public override string ToString() 
            => $"{Title}\n{Artist}\n{Date}\n{Genre}\n{Infos}\n";
    }
}