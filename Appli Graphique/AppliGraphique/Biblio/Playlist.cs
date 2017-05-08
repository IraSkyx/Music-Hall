using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Biblio
{
    public class Playlist : ObservableCollection<Musique>
    {
        public Playlist PlaylistProperty
        {
            get { return this; }
        }

        public Playlist()
            : base()
        {
        }

        public Playlist(IEnumerable<Musique> mus)
            :base(mus)
        {
        }

        public Playlist(Array array)
        {
            foreach(Musique m in array)
            {
                Add(m);
            }
        }

        public override string ToString()
        {
            return string.Join<Musique>("", this.ToArray());
        }
    }
}
