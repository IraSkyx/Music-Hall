using System;
using System.ComponentModel;

namespace Biblio
{
    public class Musique : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;   
        private string _Title;
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
        public string Date { get; set; }
        public string Genre { get; set; }
        public string Infos { get; set; }
        public Uri Audio { get; set; }
        private string _Image;
        public string Image
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

        public Musique(string Title, string Artist, string Date, string Genre, string Infos, Uri Audio, string Image)
        {
            this.Title = Title;
            this.Artist = Artist;
            this.Date = Date;
            this.Genre = Genre;
            this.Infos = Infos;
            this.Audio = Audio;
            this.Image = Image;           
        }

        public Musique()
        {
        }

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, null))
                return false;

            if (ReferenceEquals(this, o))
                return true;

            if (GetType() != o.GetType())
                return false;

            return Equals(o as Musique);
        }

        public bool Equals(Musique other) => (Title.Equals(other.Title) && Artist.Equals(other.Artist) && Date.Equals(other.Date) && Genre.Equals(other.Genre)
                && Infos.Equals(other.Infos) && Audio.ToString().Equals(other.Audio.ToString()) && Image.Equals(other.Image));

        public override string ToString() => $"{Title}\n{Artist}\n{Date}\n{Genre}\n{Infos}\n";
    }
}