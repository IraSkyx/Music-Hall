using System.Collections.Generic;
using System.IO;

namespace Biblio
{
    public class LoadMusic
    {   
        public static List <Musique> Load()
        {
            List<Musique> liste = new List<Musique>();
            using (StreamReader str = new StreamReader(@"..\..\..\resources\File.txt"))
            {
                while (!str.EndOfStream)
                {
                    liste.Add(new Musique(str.ReadLine(), str.ReadLine(), str.ReadLine(), str.ReadLine(), str.ReadLine(), str.ReadLine(), str.ReadLine()));
                }
            }
            return liste;
        }
    }
}
