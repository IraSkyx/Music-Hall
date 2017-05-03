using Biblio;
using System;

namespace MainTest
{
    class Program
    {
        void Stub()
        {
            Musique m1 = new Musique("T1", "A1", "D1", "G1", "I1", "O1", "Im1");
            Musique m2 = new Musique("T2", "A2", "D2", "G2", "I2", "O2", "Im2");
            Musique m3 = new Musique("T3", "A3", "D3", "G3", "I3", "O3", "Im3");
            Playlist playl = new Playlist();
            playl.AddMusic(m1);
            playl.AddMusic(m2);
            playl.AddMusic(m3);
            User jean = new User("Toto", "toto@gmail.com", "toto", playl);
        }
    }
}
