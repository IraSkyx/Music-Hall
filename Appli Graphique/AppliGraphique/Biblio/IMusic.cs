using System;

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
        string Image { get; set; }

        string ToString();
        bool Equals(Object o);
        bool Equals(IMusic other);
    }
}