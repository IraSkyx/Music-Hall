using System;
using System.Collections.ObjectModel;
using System.Resources;
using System.Windows.Media.Imaging;

namespace Biblio
{
    public class LoadMusic
    {   
        public static ObservableCollection <Musique> Load()
        {
            ObservableCollection<Musique> liste = new ObservableCollection<Musique>();

            liste.Add(new Musique("T1", "A1", "D1", "G1", "I1", "O1", "Resources/eFeder.jpg"));
            liste.Add(new Musique("T2", "A2", "D2", "G2", "I2", "O2", "Resources/eFeder.jpg"));
            liste.Add(new Musique("T3", "A3", "D3", "G3", "I3", "O3", "Resources/eFeder.jpg"));

            return liste;
        }
    }
}
