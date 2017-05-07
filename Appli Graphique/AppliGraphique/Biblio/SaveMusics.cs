using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Biblio
{
    public class SaveMusics
    {
        public static void Save(ObservableCollection<Musique> AllMusics)
        {
            var musicElts = AllMusics.Select(music => new JObject(
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
