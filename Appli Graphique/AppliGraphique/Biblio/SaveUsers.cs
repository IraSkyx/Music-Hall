using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Biblio
{
    public class SaveUsers
    {
        public static void Save(ObservableCollection<User> AllUsers)
        {
            var userElts = AllUsers.Select(user => new JObject(
                                                                    new JProperty("user",
                                                                        new JObject(
                                                                            new JProperty("infos", JToken.FromObject(user.Infos)),
                                                                            new JProperty("psswd", user.Psswd),
                                                                            new JProperty("playlist", (user.Favorite==null) ? "" : JsonConvert.SerializeObject(user.Favorite))))));

            var usersFichier = new JObject(new JProperty("users", userElts));
            File.WriteAllText("AllUsers.json", usersFichier.ToString());
        }
    }
}
