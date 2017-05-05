using Biblio;
using System;
using System.Net.Mail;

namespace MainTest
{
    class Program
    {
        void Stub()
        {
            Musique m1 = new Musique("T1", "A1", "D1", "G1", "I1", new Uri("O1"), "Im1");
            Musique m2 = new Musique("T2", "A2", "D2", "G2", "I2", new Uri("O2"), "Im2");
            Musique m3 = new Musique("T3", "A3", "D3", "G3", "I3", new Uri("O3"), "Im3");
            Playlist playl = new Playlist();
            playl.AddMusic(m1);
            playl.AddMusic(m2);
            playl.AddMusic(m3);
            User jean = new User(new MailAddress("Toto", "toto@gmail.com"), "toto", playl);
        }

        static void Main(string[] args)
        {
            Musique m1 = new Musique("T1", "A1", "D1", "G1", "I1", new Uri("O1"), "Im1");
            Musique m2 = new Musique("T2", "A2", "D2", "G2", "I2", new Uri("O2"), "Im2");
            Musique m3 = new Musique("T3", "A3", "D3", "G3", "I3", new Uri("O3"), "Im3");
            Playlist playl = new Playlist();
            playl.AddMusic(m1);
            playl.AddMusic(m2);
            playl.AddMusic(m3);
            User jean = new User(new MailAddress("Toto", "toto@gmail.com"), "toto", playl);
            Console.WriteLine(jean);

        }
    }
}
