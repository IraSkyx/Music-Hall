using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Biblio
{
    /// <summary>
    /// Classe permettant de gérer l'instanciation des Progressbar servant au SongDetail
    /// </summary>
    public class Equalizer
    {
        /// <summary>
        /// Dictionnaire contenant les ProgressBar du SongDetail
        /// </summary>
        public Dictionary<int, ProgressBar> MyProgs = new Dictionary<int, ProgressBar>();

        /// <summary>
        /// Constructeur de Equalizer
        /// </summary>
        /// <param name="NumberOfInstances"> Donne le nombre d'entités à instancier dans le dictionnaire </param>
        public Equalizer(int NumberOfInstances)
        {
            for(int i=0; i< NumberOfInstances; ++i)
            {
                ProgressBar bar = new ProgressBar()
                {
                    Maximum = 100,
                    Minimum = 0,
                    Margin = new Thickness(0, 1, 0, 1),
                    Background = Brushes.Transparent,
                    Foreground = new SolidColorBrush(Color.FromRgb(23, 23, 23)),
                    BorderThickness = new Thickness(0)

                };
                BindingOperations.SetBinding(bar, ProgressBar.HeightProperty, new Binding()
                {
                    Path = new PropertyPath("ActualWidth"),
                    Converter = new ValueToContent(),
                });
                MyProgs.Add(i, bar);
            }
        }
    }
}