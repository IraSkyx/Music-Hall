using Biblio;
using System;
using static System.Console;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading;

namespace MainTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /* ----- MAKER ----- */

            //Create a player
            Player myPlayer = new Player();

            //Create comments
            ObservableCollection<Comment> Com = new ObservableCollection<Comment>();
            Com.Add(new Comment("Toto", 4, "lolol"));
            Com.Add(new Comment("Toto2", 2, "lolol2"));

            //Create Musics
            IMusic music1 = MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FvDk9paBf9I", "images/eFeder.jpg", Com);
            IMusic music2 = MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/ktBMxkLUIwY", "images/eHolding.jpg", Com);

            //Create a playlist
            Playlist list = new Playlist(music1, music2);

            //Create a User
            IUser toto = UserMaker.MakeUser("toto@gmail.com", "toto", "toto", list);

            /* ----- MAKER ----- */

            /* ----- DISPLAY ----- */

            //Display a User
            WriteLine(toto);

            //Display a Music
            WriteLine(music1);

            //Display a playlist
            WriteLine(list);

            //Display a comment
            WriteLine(Com.ElementAt(0));

            /* ----- DISPLAY ----- */

            /* ----- USING ----- */

            myPlayer.CurrentUser = toto;
            myPlayer.Play(music1);
            Thread.Sleep(10000);
            myPlayer.GoToNextOrPrevious(1);
            Thread.Sleep(10000);
            myPlayer.GoToNextOrPrevious(-1);
            Thread.Sleep(10000);

            /* ----- USING ----- */
        }
    }
}
