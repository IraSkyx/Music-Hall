using System;
using System.Collections.ObjectModel;

namespace Biblio
{
    /// <summary>
    /// Interface définissant les attributs essentiels d'une Musique
    /// </summary>
    public interface IMusic
    {
        /// <summary>
        /// Titre de la musique
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Artiste de la musique
        /// </summary>
        string Artist { get; set; }

        /// <summary>
        /// Date de la musique
        /// </summary>
        string Date { get; set; }

        /// <summary>
        /// Genre de la musique
        /// </summary>
        string Genre { get; set; }

        /// <summary>
        /// Infos complémentaires sur la musique
        /// </summary>
        string Infos { get; set; }

        /// <summary>
        /// Audio de la musique
        /// </summary>
        Uri Audio { get; set; }

        /// <summary>
        /// Video de la musique
        /// </summary>
        string Video { get; set; }

        /// <summary>
        /// Image de la musique
        /// </summary>
        Uri Image { get; set; }

        /// <summary>
        /// Comments de la musique
        /// </summary>
        ObservableCollection<IComment> Comments { get; set; }

        /// <summary>
        /// Permet d'ajouter un Comment à la Music
        /// </summary>
        /// <param name="Com"> Comment à ajouter </param>
        void AddComment(IComment Com);
    }
}