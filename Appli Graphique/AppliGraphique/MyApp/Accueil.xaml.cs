using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Accueil : UserControl
    {        
        private ListView MyScroller =  ((ListView) Application.Current.MainWindow.FindName("MyScroller"));
        private Lecteur MyPlayer = ((Lecteur)Application.Current.MainWindow.FindName("MyPlayer"));

        public Accueil()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sélectionne dans la ListView supérieure la musique sélectionné depuis la page d'Accueil
        /// </summary>
        /// <param name="sender"> Objet envoyeur </param>
        /// <param name="e"> Évènements du clic de souris </param>
        private void Home_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ReferenceEquals(World, sender))
                MyScroller.SelectedIndex = MyPlayer.Allmusics.SelectHomeMusic("T1");               
            if (ReferenceEquals(France, sender))
                MyScroller.SelectedIndex = MyPlayer.Allmusics.SelectHomeMusic("T5");
            if (ReferenceEquals(Hall, sender))
                MyScroller.SelectedIndex = MyPlayer.Allmusics.SelectHomeMusic("T6");
            ((TabControl)Application.Current.MainWindow.FindName("Tab")).SelectedIndex = 1;
        }
    }
}
