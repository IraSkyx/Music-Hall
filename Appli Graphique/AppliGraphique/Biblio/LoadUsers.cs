using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace Biblio
{
    public class LoadUsers
    {
        public static ObservableCollection<User> Load()
        {
            //Test 1

            /*JObject json;
            try
            {
                json = JObject.Parse(File.ReadAllText("AllUsers.json"));
            }
            catch (FileNotFoundException)
            {
                yield break;
            }
            string jsonString = @"{
                    'Title': 'T1',
                    'Artist': A1,
                    'Date': 'D1',
                    'Genre': 'G1',
                    'Infos': 'I1',
                    'Audio': 'audio/Feder.mp3',
                    'Image': 'images/eFeder.jpg',
                         }";

            foreach (JObject j in json["users"])
            {
                yield return new User(
                    new MailAddress((string)j["user"]["infos"]["Address"], (string)j["user"]["infos"]["DisplayName"]),
                    (string)j["user"]["psswd"],
                    new Playlist(JsonConvert.DeserializeObject<Playlist>(jsonString))
                );
            }*/

            //Test 2

            string jsonText = File.ReadAllText("AllUsers.json");
            JObject json = JObject.Parse(jsonText);

            return new ObservableCollection<User>(json["users"].Select(j => new User()
            {
                Infos = new MailAddress((string)j["user"]["infos"]["Address"][0], (string)j["user"]["infos"]["DisplayName"][0]),
                Psswd = (string)j["user"]["psswd"][0],
                Favorite = new Playlist(json["users"]["playlist"][0].Select(elt => new Musique()
                {
                    Title = (string)elt["musique"]["title"][0],
                    Artist = (string)elt["musique"]["nom"][0],
                    Date = (string)elt["musique"]["date"][0],
                    Genre = (string)elt["musique"]["genre"][0],
                    Infos = (string)elt["musique"]["infos"][0],
                    Audio = new Uri((string)elt["musique"]["audio"][0], UriKind.RelativeOrAbsolute),
                    Image = (string)elt["musique"]["image"][0]
                }))
            }));
        }
    }
}
