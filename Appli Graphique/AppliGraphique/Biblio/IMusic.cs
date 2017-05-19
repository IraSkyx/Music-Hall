using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Biblio
{
    [DataContract]
    public abstract class IMusic
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

        [DataMember(Name = "Image", Order = 6)]
        public string Image { get; set; }

        public ObservableCollection<Comment> Comments { get; set; }
    }
}