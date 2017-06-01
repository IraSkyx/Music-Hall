using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Biblio
{
    [DataContract]
    internal class Music : IMusic
    {
        [DataMember(Name = "Title", Order = 0)]
        public string Title { get; set; }

        [DataMember(Name = "Artist", Order = 1)]
        public string Artist { get; set; }

        [DataMember(Name = "Date", Order = 2)]
        public string Date { get; set; }

        [DataMember(Name = "Genre", Order = 3)]
        public string Genre { get; set; }

        [DataMember(Name = "Infos", Order = 4)]
        public string Infos { get; set; }

        [DataMember(Name = "Audio", Order = 5)]
        public Uri Audio { get; set; }

        [DataMember(Name = "Video", Order = 6)]
        public string Video { get; set; }

        [DataMember(Name = "Image", Order = 7)]
        public string Image { get; set; }     

        [DataMember(Name = "Comments", Order = 8)]
        public ObservableCollection<IComment> Comments { get; set; }

        /// <summary>
        /// Constructeur de Music
        /// </summary>
        public Music(string Title, string Artist, string Date, string Genre, string Infos, Uri Audio, string Video, string Image, ObservableCollection<IComment> Comments)
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
            => (Title.Equals(other.Title) && Artist.Equals(other.Artist) && Date.Equals(other.Date) && Genre.Equals(other.Genre) && Infos.Equals(other.Infos) && Audio.ToString().Equals(other.Audio.ToString()) && Video.Equals(other.Video) && Image.Equals(other.Image));

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