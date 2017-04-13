using Biblio;
using System;
using System.Linq;

namespace MainTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadFiles loading = new LoadFiles();
            loading.CopyDirectory();
            loading.Load();
            foreach(Musique music in loading.AllMusic)
            {
                Console.WriteLine(music);
            }

            Playlist favorite = new Playlist();
            favorite.AddMusic(loading.AllMusic.ElementAt(0));
            favorite.AddMusic(loading.AllMusic.ElementAt(1));
            favorite.AddMusic(loading.AllMusic.ElementAt(2));
            favorite.AddMusic(loading.AllMusic.ElementAt(3));

            User user = new User("Adrien", "adrien.lenoir@gmail.com", "adrien", favorite);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(favorite);
            Console.WriteLine("-----------------------------------");

            Player lecteur = new Player();

            PlayerManager manager = new PlayerManager(lecteur,favorite);

            manager.SetNext();
            manager.SetNext();

            /*for(int i = 0; i < 49; ++i)
            {
                manager.SetVolume(50 - i);
                Thread.Sleep(250);
            }*/
            manager.SetVolume(70);

            System.Threading.Thread.Sleep(1000000000);

            /*Console.WriteLine("Tapez P pour mettre en pause");
            string a = Console.ReadLine();
            manager.PausePlay();

            Console.WriteLine("Tapez R pour relancer");
            a = Console.ReadLine();
            manager.PausePlay();*/

        }
    }
}
