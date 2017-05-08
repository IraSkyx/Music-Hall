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
        {
        }

        public Playlist(IEnumerable<Musique> mus)
            :base(mus)
        {
        }

        public override string ToString() => string.Join<Musique>("", this.ToArray());
    }
}
