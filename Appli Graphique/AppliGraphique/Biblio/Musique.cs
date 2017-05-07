using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Biblio
{
    public class Musique : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Artist")]
        public string Artist { get; set; }
        [JsonProperty("Date")]
        public string Date { get; set; }
        [JsonProperty("Genre")]
        public string Genre { get; set; }
        [JsonProperty("Infos")]
        public string Infos { get; set; }
        [JsonProperty("Audio")]
        public Uri Audio { get; set; }
        [JsonProperty("Image")]
        public string Image { get; set; }

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