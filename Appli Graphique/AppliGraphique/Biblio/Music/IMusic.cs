using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Biblio
{
    public interface IMusic
    {
        string Title { get; set; }

        string Artist { get; set; }

        string Date { get; set; }

        string Genre { get; set; }

        string Infos { get; set; }

        Uri Audio { get; set; }

        string Video { get; set; }

        Uri Image { get; set; }

        ObservableCollection<IComment> Comments { get; set; }

        void AddComment(IComment value);
    }
}