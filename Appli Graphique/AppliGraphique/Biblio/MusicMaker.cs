using System;

namespace Biblio
{
    public class MusicMaker
    {
        public static IMusic MakeMusic(string Title, string Artist, string Date, string Genre, string Infos, Uri Audio, string Image)
            => new Music(Title, Artist, Date, Genre, Infos, Audio, Image);
    }
}
