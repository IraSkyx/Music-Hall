using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {        
        private ListView scroller =  ((ListView) Application.Current.MainWindow.FindName("scroller"));
        private Lecteur lecteur = ((Lecteur)Application.Current.MainWindow.FindName("lecteur"));

        public Home()
        {
            InitializeComponent();
        }

        private void Home_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ReferenceEquals(world, sender))
                scroller.SelectedIndex = lecteur.Allmusics.SelectHomeMusic("T1");               
            if (ReferenceEquals(france, sender))
                scroller.SelectedIndex = lecteur.Allmusics.SelectHomeMusic("T5");
            if (ReferenceEquals(hall, sender))
                scroller.SelectedIndex = lecteur.Allmusics.SelectHomeMusic("T6");
            ((TabControl)Application.Current.MainWindow.FindName("Tab")).SelectedIndex = 1;
        }
    }
}
