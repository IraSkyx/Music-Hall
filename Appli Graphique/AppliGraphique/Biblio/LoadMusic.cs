using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;

namespace Biblio
{
    public class LoadMusic
    {   
        public static Playlist Load()
        {
            JObject json = JObject.Parse(File.ReadAllText("AllMusics.json"));

            return new Playlist(json["musiques"].Select(j => new Musique()
            {
                Title = (string)j["musique"]["title"],
                Artist = (string)j["musique"]["nom"],
                Date = (string)j["musique"]["date"],
                Genre = (string)j["musique"]["genre"],
                Infos = (string)j["musique"]["infos"],
                Audio = new Uri((string)j["musique"]["audio"], UriKind.RelativeOrAbsolute),
                Image = (string)j["musique"]["image"]
            }).ToList());
        }
    }
}
