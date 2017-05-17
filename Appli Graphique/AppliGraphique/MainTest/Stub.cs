using Biblio;
using System;
using System.Net.Mail;

namespace MainTest
{
    public class Stub
    {
        public static Playlist LoadMusicsTest()
        {
            Playlist liste = new Playlist();

            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "images/eFeder.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T2", "A2", "D2", "G2", "I2", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "images/eHolding.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T3", "A3", "D3", "G3", "I3", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "images/eShelter.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "images/eJustLike.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T5", "A5", "D5", "G5", "I5", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "images/eParis.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T6", "A6", "D6", "G6", "I6", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "images/eAintMe.jpg"));

            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "images/eFeder.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T2", "A2", "D2", "G2", "I2", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "images/eHolding.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T3", "A3", "D3", "G3", "I3", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "images/eShelter.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "images/eJustLike.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T5", "A5", "D5", "G5", "I5", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "images/eParis.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T6", "A6", "D6", "G6", "I6", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "images/eAintMe.jpg"));

            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "images/eFeder.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T2", "A2", "D2", "G2", "I2", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "images/eHolding.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T3", "A3", "D3", "G3", "I3", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "images/eShelter.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "images/eJustLike.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T5", "A5", "D5", "G5", "I5", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "images/eParis.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T6", "A6", "D6", "G6", "I6", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "images/eAintMe.jpg"));

            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "images/eFeder.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T2", "A2", "D2", "G2", "I2", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "images/eHolding.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T3", "A3", "D3", "G3", "I3", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "images/eShelter.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "images/eJustLike.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T5", "A5", "D5", "G5", "I5", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "images/eParis.jpg"));
            liste.PlaylistProperty.Add(MusicMaker.MakeMusic("T6", "A6", "D6", "G6", "I6", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "images/eAintMe.jpg"));


            return liste;
        }

        public static UserDB LoadUsersTest()
        {
            UserDB liste = new UserDB();

            Playlist playlist = new Playlist();
            playlist.PlaylistProperty.Add(MusicMaker.MakeMusic("T1", "A1", "D1", "G1", "I1", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "images/eFeder.jpg"));
            playlist.PlaylistProperty.Add(MusicMaker.MakeMusic("T4", "A4", "D4", "G4", "I4", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "images/eJustLike.jpg"));

            liste.Database.Add(UserMaker.MakeUser(new MailAddress("toto@gmail.com","toto"), "toto", playlist));

            return liste;
        }
    }
}
