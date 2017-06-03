using Biblio;

namespace BackEnd
{
    public class PlayerFront
    {
        public Player MyPlayer { get; set; }

        public PlayerFront()
        {
            MyPlayer = new Player();
        }
    }
}
