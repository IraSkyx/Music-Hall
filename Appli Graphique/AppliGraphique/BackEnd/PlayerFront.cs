using Biblio;

namespace BackEnd
{
    /// <summary>
    /// Classe instanciant un Player pour que la vue y ait accès statiquement
    /// </summary>
    public class PlayerFront
    {
        /// <summary>
        /// Lecteur permettant de lire et gérer des Musics
        /// </summary>
        public static Player MyPlayer { get; set; }

        /// <summary>
        /// Instancie un Player
        /// </summary>
        public static void LoadPlayer()
        {
            MyPlayer = new Player();
        }
    }
}
