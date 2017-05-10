using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

namespace Biblio
{
    public class SaveMusics
    {
        public static void Save(Playlist AllMusics)
        {
            var musicElts = AllMusics.PlaylistProperty.Select(music => new JObject(
                                                                    new JProperty("musique",
                                                                        new JObject(
                                                                            new JProperty("title", music.Title),
                                                                            new JProperty("artist", music.Artist),
                                                                            new JProperty("date", music.Date),
                                                                            new JProperty("genre", music.Genre),
                                                                            new JProperty("infos", music.Infos),
                                                                            new JProperty("audio", JsonConvert.ToString(music.Audio)),
                                                                            new JProperty("image", music.Image)))));

            var musiquesFichier = new JObject(new JProperty("musiques", musicElts));
            File.WriteAllText("AllMusics.json", musiquesFichier.ToString());
        }
    }
}
