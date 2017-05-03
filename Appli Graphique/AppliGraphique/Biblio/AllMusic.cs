using System.Collections.ObjectModel;

namespace Biblio
{
    public class AllMusic
    {
        public ObservableCollection<Musique> All { get; set; }

        public AllMusic()
        {
            All = new ObservableCollection<Musique>();
        }
    }
}
