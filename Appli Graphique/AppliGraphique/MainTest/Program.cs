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

            //Create a player
            PlayerFront Front = new PlayerFront();

            //Load Music DB
            PlaylistFront.LoadMusics();

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

            Front.MyPlayer.CurrentUser = UserDBFront.MyUserDB.Database.ElementAt(0);
            Front.MyPlayer.Play(PlaylistFront.AllMusics.PlaylistProperty.ElementAt(0));
            Thread.Sleep(10000);
            Front.MyPlayer.GoToNextOrPrevious(1);
            Thread.Sleep(10000);
            Front.MyPlayer.GoToNextOrPrevious(-1);
            Thread.Sleep(10000);

            /* ----- USING ----- */
        }
    }
}
