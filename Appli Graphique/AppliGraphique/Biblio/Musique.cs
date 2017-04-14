namespace Biblio
{
    public class Musique
    {
        public string Title;
        public string Artist;
        public string Date;
        public string Genre;
        public string Info;
        public string Audio;
        public string Image;

        public Musique(string Title, string Artist, string Date, string Genre, string Info, string Audio, string Image)
        {
            this.Title = Title;
            this.Artist = Artist;
            this.Date = Date;
            this.Genre = Genre;
            this.Info = Info;
            this.Audio = Audio;
            this.Image = Image;           
        }

        public override string ToString()
        {          
            return $"{Title}\n{Artist}\n{Date}\n{Genre}\n{Info}";
        }
    }
}