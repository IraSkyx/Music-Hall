using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Biblio
{
    public class Musique : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Date { get; set; }
        public string Genre { get; set; }
        public string Infos { get; set; }    
        public Uri Audio { get; set; }
        private string image;
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
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

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {          
            return $"{Title}\n{Artist}\n{Date}\n{Genre}\n{Infos}\n";
        }
    }
}