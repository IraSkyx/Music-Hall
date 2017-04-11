using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyApp
{
    internal class Musique
    {
        
        public string audio { get; set; }
        public string image { get; set; }

        public Musique(string audio, string image)
        {
            this.audio = audio;
            this.image = image;           
        }
    }
}