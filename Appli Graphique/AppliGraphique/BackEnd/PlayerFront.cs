using Biblio;

namespace BackEnd
{
    public class PlayerFront
    {
        public static Player MyPlayer { get; set; }

        public static void LoadPlayer()
        {
            MyPlayer = new Player();
        }
    }
}
