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
        public static IEnumerable<User> Load()
        {
            /*ObservableCollection<User> liste = new ObservableCollection<User>();

            Playlist playlist = new Playlist();
            playlist.AddMusic(new Musique("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "images/eFeder.jpg"));
            playlist.AddMusic(new Musique("T1", "A1", "D1", "G1", "I1", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "images/eJustLike.jpg"));

            liste.Add(new User(new MailAddress("toto@gmail.com","toto"), "toto", playlist));

            return liste;*/

            JObject json = JObject.Parse(File.ReadAllText("AllUsers.json"));

            /*string js = @"{
                    'Title': 'T1',
                    'Artist': A1,
                    'Date': '00/00/0000',
                    'Genre': G1,
                    'Audio': Feder.mp3,
                    'Image': eFeder.jpg,
                         }";*/

            foreach (JObject j in json["users"])
            {
                yield return new User(
                    new MailAddress((string)j["user"]["infos"]["Address"], (string)j["user"]["infos"]["DisplayName"]),
                    (string)j["user"]["psswd"],
                    JsonConvert.DeserializeObject<Playlist>((string)json)
                );
            }
        }
    }
}
