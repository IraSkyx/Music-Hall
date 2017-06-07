using System;
using static System.Console;
using System.Linq;
using System.Threading;
using BackEnd;

namespace MainTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /* ----- MAKER ----- */

            //Load Music DB
            PlaylistFront.LoadMusics();

            //Load Music DB
            PlayerFront.LoadPlayer();

            //Load User DB
            UserDBFront.LoadUsers();

            /* ----- MAKER ----- */

            /* ----- DISPLAY ----- */

            //Display a User
            WriteLine(UserDBFront.MyUserDB.Database.ElementAt(0));

            //Display a Music
            WriteLine(PlaylistFront.AllMusics.PlaylistProperty.ElementAt(0));

            //Display a playlist
            WriteLine(PlaylistFront.AllMusics);

            //Display a comment
            WriteLine(PlaylistFront.AllMusics.PlaylistProperty.ElementAt(0));

            /* ----- DISPLAY ----- */

            /* ----- USING ----- */

            PlayerFront.MyPlayer.CurrentUser = UserDBFront.MyUserDB.Database.ElementAt(0);
            PlayerFront.MyPlayer.Play(PlaylistFront.AllMusics.PlaylistProperty.ElementAt(0));
            Thread.Sleep(10000);
            PlayerFront.MyPlayer.GoToNextOrPrevious(1);
            Thread.Sleep(10000);
            PlayerFront.MyPlayer.GoToNextOrPrevious(-1);
            Thread.Sleep(10000);

            /* ----- USING ----- */
        }
    }
}
