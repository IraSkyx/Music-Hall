namespace MyApp
{
    internal class Musique
    {
        /*public string titre
        {
            get { return titre; }
            private set { titre = value; }
        }
        public string artiste
        {
            get { return artiste; }
            private set { artiste = value; }
        }
        public string infos
        {
            get { return infos; }
            private set { infos = value; }
        }
        public string image
        {
            get { return image; }
            private set { image = value; }
        }
        public string date
        {
            get { return date; }
            private set { date = value; }
        }
        public string audio
        {
            get { return audio; }
            private set { audio = value; }
        }
        public int duree
        {
            get { return duree; }
            private set { duree = value; }
        }*/

        public string titre;

        public string artiste;

        public string infos;

        public string image;

        public string date;

        public string audio;

        public int duree;
        

        public Musique(string titre, string artiste, string infos, string image, string date, string audio, int duree)
        {
            this.titre = titre;
            this.artiste = artiste;
            this.infos = infos;          
            this.image = image;
            this.date = date;
            this.audio = audio;
            this.duree = duree;
        }
    }
}