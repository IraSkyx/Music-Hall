using Biblio;
using System.Windows.Controls;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Selection.xaml
    /// </summary>
    public partial class Selection : UserControl
    {
        public Musique Selected { get; set; }
        
        public Selection()
        {
            InitializeComponent();
        }

        private void PlayASong(object sender, System.Windows.RoutedEventArgs e)
        {
            Selected = (Musique)DataContext;
        }
    }
}
