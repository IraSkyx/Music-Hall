using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Biblio
{
    public class LoadMusic
    {   
        public static ObservableCollection <Musique> Load()
        {
            ObservableCollection<Musique> liste = new ObservableCollection<Musique>();

            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "images");           

            liste.Add(new Musique("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eFeder.jpg")));
            liste.Add(new Musique("T2", "A2", "D2", "G2", "I2", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eHolding.jpg")));
            liste.Add(new Musique("T3", "A3", "D3", "G3", "I3", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eShelter.jpg")));
            liste.Add(new Musique("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eJustLike.jpg")));
            liste.Add(new Musique("T5", "A5", "D5", "G5", "I5", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eParis.jpg")));
            liste.Add(new Musique("T6", "A6", "D6", "G6", "I6", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eAintMe.jpg")));

            liste.Add(new Musique("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eFeder.jpg")));
            liste.Add(new Musique("T2", "A2", "D2", "G2", "I2", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eHolding.jpg")));
            liste.Add(new Musique("T3", "A3", "D3", "G3", "I3", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eShelter.jpg")));
            liste.Add(new Musique("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eJustLike.jpg")));
            liste.Add(new Musique("T5", "A5", "D5", "G5", "I5", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eParis.jpg")));
            liste.Add(new Musique("T6", "A6", "D6", "G6", "I6", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eAintMe.jpg")));

            liste.Add(new Musique("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eFeder.jpg")));
            liste.Add(new Musique("T2", "A2", "D2", "G2", "I2", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eHolding.jpg")));
            liste.Add(new Musique("T3", "A3", "D3", "G3", "I3", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eShelter.jpg")));
            liste.Add(new Musique("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eJustLike.jpg")));
            liste.Add(new Musique("T5", "A5", "D5", "G5", "I5", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eParis.jpg")));
            liste.Add(new Musique("T6", "A6", "D6", "G6", "I6", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eAintMe.jpg")));

            liste.Add(new Musique("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eFeder.jpg")));
            liste.Add(new Musique("T2", "A2", "D2", "G2", "I2", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eHolding.jpg")));
            liste.Add(new Musique("T3", "A3", "D3", "G3", "I3", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eShelter.jpg")));
            liste.Add(new Musique("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eJustLike.jpg")));
            liste.Add(new Musique("T5", "A5", "D5", "G5", "I5", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eParis.jpg")));
            liste.Add(new Musique("T6", "A6", "D6", "G6", "I6", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), Path.Combine(strFilePath, "eAintMe.jpg")));

            return liste;
        }
    }
}
