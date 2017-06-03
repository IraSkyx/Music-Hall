using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Biblio
{
    public class Equalizer
    {
        public Dictionary<int, ProgressBar> MyProgs = new Dictionary<int, ProgressBar>();

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
