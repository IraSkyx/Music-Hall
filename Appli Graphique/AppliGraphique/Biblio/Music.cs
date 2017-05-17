using System;

namespace Biblio
{
    internal class Music : IMusic
    { 
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Date { get; set; }
        public string Genre { get; set; }
        public string Infos { get; set; }
        public Uri Audio { get; set; }
        public string Image { get; set; }

        /// <summary>
        /// Constructeur de Music
        /// </summary>
        public Music(string Title, string Artist, string Date, string Genre, string Infos, Uri Audio, string Image)
        {
            this.Title = Title;
            this.Artist = Artist;
            this.Date = Date;
            this.Genre = Genre;
            this.Infos = Infos;
            this.Audio = Audio;
            this.Image = Image;           
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
            => (Title.Equals(other.Title) && Artist.Equals(other.Artist) && Date.Equals(other.Date) && Genre.Equals(other.Genre) && Infos.Equals(other.Infos) && Audio.ToString().Equals(other.Audio.ToString()) && Image.Equals(other.Image));

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