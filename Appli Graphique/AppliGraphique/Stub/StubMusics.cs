﻿using Biblio;
using System;
using System.Collections.ObjectModel;

namespace Stub
{
    /// <summary>
    /// Classe de chargement en dur dans le code
    /// </summary>
    public class StubMusics : Data
    {
        /// <summary>
        /// Charge en dur une Database de Music
        /// </summary>
        /// <returns> La Database de Music fabriquée </returns>
        public static Playlist LoadMusics()
        {           
            ObservableCollection<IComment> Com = new ObservableCollection<IComment>
            {
                CommentMaker.MakeComment("Toto1", 4, "lolol"),
                CommentMaker.MakeComment("Toto11", 2, "lolol")
            };

            ObservableCollection<IComment> Com2 = new ObservableCollection<IComment>
            {
                CommentMaker.MakeComment("Toto2", 4, "lolol"),
                CommentMaker.MakeComment("Toto22", 2, "lolol")
            };

            ObservableCollection<IComment> Com3 = new ObservableCollection<IComment>
            {
                CommentMaker.MakeComment("Toto3", 4, "lolol"),
                CommentMaker.MakeComment("Toto33", 2, "lolol")
            };

            ObservableCollection<IComment> Com4 = new ObservableCollection<IComment>
            {
                CommentMaker.MakeComment("Toto4", 4, "lolol"),
                CommentMaker.MakeComment("Toto44", 2, "lolol")
            };

            ObservableCollection<IComment> Com5 = new ObservableCollection<IComment>
            {
                CommentMaker.MakeComment("Toto5", 4, "lolol"),
                CommentMaker.MakeComment("Toto55", 2, "lolol")
            };

            ObservableCollection<IComment> Com6 = new ObservableCollection<IComment>
            {
                CommentMaker.MakeComment("Toto6", 4, "lolol"),
                CommentMaker.MakeComment("Toto66", 2, "lolol")
            };

            return new Playlist()
            {
                PlaylistProperty = new ObservableCollection<IMusic>()
                {
                    MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "FvDk9paBf9I", new Uri("pack://application:,,,/Resources;Component/eFeder.jpg", UriKind.RelativeOrAbsolute), Com),
                    MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "ktBMxkLUIwY", new Uri("pack://application:,,,/Resources;Component/eHolding.jpg", UriKind.RelativeOrAbsolute), Com2),
                    MusicMaker.MakeMusic("Shelter", "Porter Robinson & Madeon", "2016", "Dance, Musique de danse, Electro house, Nu-disco, Pop", "Visualizer created by : Tim Hendrix", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "HQnC1UHBvWA", new Uri("pack://application:,,,/Resources;Component/eShelter.jpg", UriKind.RelativeOrAbsolute), Com3),
                    MusicMaker.MakeMusic("Something Just Like This", "The Chainsmokers & Coldplay", "2017", "Dance", "Directed by James Zwadlo", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "FM7MFYoylVs", new Uri("pack://application:,,,/Resources;Component/eJustLike.jpg", UriKind.RelativeOrAbsolute), Com4),
                    MusicMaker.MakeMusic("Paris", "The Chainsmokers", "2017", "Pop, Dance", "Directed by Rory Kramer", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "RhU9MZ98jxo", new Uri("pack://application:,,,/Resources;Component/eParis.jpg", UriKind.RelativeOrAbsolute), Com5),
                    MusicMaker.MakeMusic("It Ain't Me", "Kygo, Selena Gomez", "2017", "House, Dance, Pop", "License to Sony Music Entertainment International Ltd / Ultra Records, LLC", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "D5drYkLiLI8", new Uri("pack://application:,,,/Resources;Component/eAintMe.jpg", UriKind.RelativeOrAbsolute), Com6),

                    MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "FvDk9paBf9I", new Uri("pack://application:,,,/Resources;Component/eFeder.jpg", UriKind.RelativeOrAbsolute), Com),
                    MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "ktBMxkLUIwY", new Uri("pack://application:,,,/Resources;Component/eHolding.jpg", UriKind.RelativeOrAbsolute), Com2),
                    MusicMaker.MakeMusic("Shelter", "Porter Robinson & Madeon", "2016", "Dance, Musique de danse, Electro house, Nu-disco, Pop", "Visualizer created by : Tim Hendrix", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "HQnC1UHBvWA", new Uri("pack://application:,,,/Resources;Component/eShelter.jpg", UriKind.RelativeOrAbsolute), Com3),
                    MusicMaker.MakeMusic("Something Just Like This", "The Chainsmokers & Coldplay", "2017", "Dance", "Directed by James Zwadlo", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "FM7MFYoylVs", new Uri("pack://application:,,,/Resources;Component/eJustLike.jpg", UriKind.RelativeOrAbsolute), Com4),
                    MusicMaker.MakeMusic("Paris", "The Chainsmokers", "2017", "Pop, Dance", "Directed by Rory Kramer", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "RhU9MZ98jxo", new Uri("pack://application:,,,/Resources;Component/eParis.jpg", UriKind.RelativeOrAbsolute), Com5),
                    MusicMaker.MakeMusic("It Ain't Me", "Kygo, Selena Gomez", "2017", "House, Dance, Pop", "License to Sony Music Entertainment International Ltd / Ultra Records, LLC", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "D5drYkLiLI8", new Uri("pack://application:,,,/Resources;Component/eAintMe.jpg", UriKind.RelativeOrAbsolute), Com6),

                    MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "FvDk9paBf9I", new Uri("pack://application:,,,/Resources;Component/eFeder.jpg", UriKind.RelativeOrAbsolute), Com),
                    MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "ktBMxkLUIwY", new Uri("pack://application:,,,/Resources;Component/eHolding.jpg", UriKind.RelativeOrAbsolute), Com2),
                    MusicMaker.MakeMusic("Shelter", "Porter Robinson & Madeon", "2016", "Dance, Musique de danse, Electro house, Nu-disco, Pop", "Visualizer created by : Tim Hendrix", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "HQnC1UHBvWA", new Uri("pack://application:,,,/Resources;Component/eShelter.jpg", UriKind.RelativeOrAbsolute), Com3),
                    MusicMaker.MakeMusic("Something Just Like This", "The Chainsmokers & Coldplay", "2017", "Dance", "Directed by James Zwadlo", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "FM7MFYoylVs", new Uri("pack://application:,,,/Resources;Component/eJustLike.jpg", UriKind.RelativeOrAbsolute), Com4),
                    MusicMaker.MakeMusic("Paris", "The Chainsmokers", "2017", "Pop, Dance", "Directed by Rory Kramer", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "RhU9MZ98jxo", new Uri("pack://application:,,,/Resources;Component/eParis.jpg", UriKind.RelativeOrAbsolute), Com5),
                    MusicMaker.MakeMusic("It Ain't Me", "Kygo, Selena Gomez", "2017", "House, Dance, Pop", "License to Sony Music Entertainment International Ltd / Ultra Records, LLC", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "D5drYkLiLI8", new Uri("pack://application:,,,/Resources;Component/eAintMe.jpg", UriKind.RelativeOrAbsolute), Com6),

                    MusicMaker.MakeMusic("Back For More", "Feder feat Daecolm", "2017", "Dance", "Directed by Julien", new Uri("audio/Feder.mp3", UriKind.RelativeOrAbsolute), "FvDk9paBf9I", new Uri("pack://application:,,,/Resources;Component/eFeder.jpg", UriKind.RelativeOrAbsolute), Com),
                    MusicMaker.MakeMusic("Holding On To You", "Twenty One Pilots", "2012", "Musique alternative/indé", "Directed by Jordan Bahat", new Uri("audio/Holding.mp3", UriKind.RelativeOrAbsolute), "ktBMxkLUIwY", new Uri("pack://application:,,,/Resources;Component/eHolding.jpg", UriKind.RelativeOrAbsolute), Com2),
                    MusicMaker.MakeMusic("Shelter", "Porter Robinson & Madeon", "2016", "Dance, Musique de danse, Electro house, Nu-disco, Pop", "Visualizer created by : Tim Hendrix", new Uri("audio/Shelter.mp3", UriKind.RelativeOrAbsolute), "HQnC1UHBvWA", new Uri("pack://application:,,,/Resources;Component/eShelter.jpg", UriKind.RelativeOrAbsolute), Com3),
                    MusicMaker.MakeMusic("Something Just Like This", "The Chainsmokers & Coldplay", "2017", "Dance", "Directed by James Zwadlo", new Uri("audio/JustLike.mp3", UriKind.RelativeOrAbsolute), "FM7MFYoylVs", new Uri("pack://application:,,,/Resources;Component/eJustLike.jpg", UriKind.RelativeOrAbsolute), Com4),
                    MusicMaker.MakeMusic("Paris", "The Chainsmokers", "2017", "Pop, Dance", "Directed by Rory Kramer", new Uri("audio/Paris.mp3", UriKind.RelativeOrAbsolute), "RhU9MZ98jxo", new Uri("pack://application:,,,/Resources;Component/eParis.jpg", UriKind.RelativeOrAbsolute), Com5),
                    MusicMaker.MakeMusic("It Ain't Me", "Kygo, Selena Gomez", "2017", "House, Dance, Pop", "License to Sony Music Entertainment International Ltd / Ultra Records, LLC", new Uri("audio/AintMe.mp3", UriKind.RelativeOrAbsolute), "D5drYkLiLI8", new Uri("pack://application:,,,/Resources;Component/eAintMe.jpg", UriKind.RelativeOrAbsolute), Com6)

                }
            };
        }
    }
}
