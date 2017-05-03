namespace Biblio
{
    public class Musique
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Date { get; set; }
        public string Genre { get; set; }
        public string Infos { get; set; }
        public string Audio { get; set; }
        public string Image { get; set; }

        public Musique(string Title, string Artist, string Date, string Genre, string Infos, string Audio, string Image)
        {
            this.Title = Title;
            this.Artist = Artist;
            this.Date = Date;
            this.Genre = Genre;
            this.Infos = Infos;
            this.Audio = Audio;
            this.Image = Image;           
        }

        public override string ToString()
        {          
            return $"{Title}\n{Artist}\n{Date}\n{Genre}\n{Infos}\n";
        }
    }
}