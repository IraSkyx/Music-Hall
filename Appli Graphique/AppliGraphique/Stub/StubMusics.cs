using Biblio;
using System;
using System.Collections.ObjectModel;

namespace Stub
{
    public class StubMusics : Data
    {
        public static Playlist LoadMusics()
        {           
            ObservableCollection<IComment> Com = new ObservableCollection<IComment>
            {
                CommentMaker.MakeComment("Toto", 4, "lolol"),
                CommentMaker.MakeComment("Toto2", 2, "lolol2")
            };

            return new Playlist()
            {
                PlaylistProperty = new ObservableCollection<IMusic>()
                {
                    MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FvDk9paBf9I", "../images/eFeder.jpg", Com),
                    MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/ktBMxkLUIwY", "../images/eHolding.jpg", Com),
                    MusicMaker.MakeMusic("Shelter", "Porter Robinson & Madeon", "2016", "Dance, Musique de danse, Electro house, Nu-disco, Pop", "Visualizer created by : Tim Hendrix", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/HQnC1UHBvWA", "../images/eShelter.jpg", Com),
                    MusicMaker.MakeMusic("Something Just Like This", "The Chainsmokers & Coldplay", "2017", "Dance", "Directed by James Zwadlo", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FM7MFYoylVs", "../images/eJustLike.jpg", Com),
                    MusicMaker.MakeMusic("Paris", "The Chainsmokers", "2017", "Pop, Dance", "Directed by Rory Kramer", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/RhU9MZ98jxo", "../images/eParis.jpg", Com),
                    MusicMaker.MakeMusic("It Ain't Me", "Kygo, Selena Gomez", "2017", "House, Dance, Pop", "License to Sony Music Entertainment International Ltd / Ultra Records, LLC", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/D5drYkLiLI8", "../images/eAintMe.jpg", Com),

                    MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FvDk9paBf9I", "../images/eFeder.jpg", Com),
                    MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/ktBMxkLUIwY", "../images/eHolding.jpg", Com),
                    MusicMaker.MakeMusic("Shelter", "Porter Robinson & Madeon", "2016", "Dance, Musique de danse, Electro house, Nu-disco, Pop", "Visualizer created by : Tim Hendrix", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/HQnC1UHBvWA", "../images/eShelter.jpg", Com),
                    MusicMaker.MakeMusic("Something Just Like This", "The Chainsmokers & Coldplay", "2017", "Dance", "Directed by James Zwadlo", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FM7MFYoylVs", "../images/eJustLike.jpg", Com),
                    MusicMaker.MakeMusic("Paris", "The Chainsmokers", "2017", "Pop, Dance", "Directed by Rory Kramer", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/RhU9MZ98jxo", "../images/eParis.jpg", Com),
                    MusicMaker.MakeMusic("It Ain't Me", "Kygo, Selena Gomez", "2017", "House, Dance, Pop", "License to Sony Music Entertainment International Ltd / Ultra Records, LLC", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/D5drYkLiLI8", "../images/eAintMe.jpg", Com),

                    MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FvDk9paBf9I", "../images/eFeder.jpg", Com),
                    MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/ktBMxkLUIwY", "../images/eHolding.jpg", Com),
                    MusicMaker.MakeMusic("Shelter", "Porter Robinson & Madeon", "2016", "Dance, Musique de danse, Electro house, Nu-disco, Pop", "Visualizer created by : Tim Hendrix", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/HQnC1UHBvWA", "../images/eShelter.jpg", Com),
                    MusicMaker.MakeMusic("Something Just Like This", "The Chainsmokers & Coldplay", "2017", "Dance", "Directed by James Zwadlo", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FM7MFYoylVs", "../images/eJustLike.jpg", Com),
                    MusicMaker.MakeMusic("Paris", "The Chainsmokers", "2017", "Pop, Dance", "Directed by Rory Kramer", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/RhU9MZ98jxo", "../images/eParis.jpg", Com),
                    MusicMaker.MakeMusic("It Ain't Me", "Kygo, Selena Gomez", "2017", "House, Dance, Pop", "License to Sony Music Entertainment International Ltd / Ultra Records, LLC", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/D5drYkLiLI8", "../images/eAintMe.jpg", Com),

                    MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FvDk9paBf9I", "../images/eFeder.jpg", Com),
                    MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/ktBMxkLUIwY", "../images/eHolding.jpg", Com),
                    MusicMaker.MakeMusic("Shelter", "Porter Robinson & Madeon", "2016", "Dance, Musique de danse, Electro house, Nu-disco, Pop", "Visualizer created by : Tim Hendrix", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/HQnC1UHBvWA", "../images/eShelter.jpg", Com),
                    MusicMaker.MakeMusic("Something Just Like This", "The Chainsmokers & Coldplay", "2017", "Dance", "Directed by James Zwadlo", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/FM7MFYoylVs", "../images/eJustLike.jpg", Com),
                    MusicMaker.MakeMusic("Paris", "The Chainsmokers", "2017", "Pop, Dance", "Directed by Rory Kramer", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/RhU9MZ98jxo", "../images/eParis.jpg", Com),
                    MusicMaker.MakeMusic("It Ain't Me", "Kygo, Selena Gomez", "2017", "House, Dance, Pop", "License to Sony Music Entertainment International Ltd / Ultra Records, LLC", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "https://www.youtube.com/embed/D5drYkLiLI8", "../images/eAintMe.jpg", Com)
                }
            };
        }
    }
}
