using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyApp
{
    internal class Musique : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string artiste { get; set; }

        public string titre { get; set; }

        public string infos { get; set; }

        public string image { get; set; }

        public string date { get; set; }

        public string audio { get; set; }

        public Musique(string titre, string artiste, string infos, string image, string date, string audio)
        {
            this.titre = titre;
            this.artiste = artiste;
            this.infos = infos;
            this.image = image;
            this.date = date;
            this.audio = audio;
        }

        //Demander ce que veut dire cette simplification
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        /*var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propName));*/
    }
}