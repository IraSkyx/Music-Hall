using BackEnd;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : UserControl
    {        
        public static readonly DependencyProperty Player = DependencyProperty.Register("MyPlayer", typeof(Lecteur), typeof(Accueil));
        public Lecteur MyPlayer
        {
            get
            {
                return GetValue(Player) as Lecteur;
            }
            set
            {
                SetValue(Player, value);
            }
        }

        public static readonly DependencyProperty Scroller = DependencyProperty.Register("MyScroller", typeof(ListView), typeof(Accueil));
        public ListView MyScroller
        {
            get
            {
                return GetValue(Scroller) as ListView;
            }
            set
            {
                SetValue(Scroller, value);
            }
        }

        public static readonly DependencyProperty Tab = DependencyProperty.Register("MyTab", typeof(TabControl), typeof(Accueil));
        public TabControl MyTab
        {
            get
            {
                return GetValue(Tab) as TabControl;
            }
            set
            {
                SetValue(Tab, value);
            }
        }

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
            MyScroller.SelectedIndex = PlaylistFront.AllMusics.SelectHomeMusic(((StackPanel)sender).Tag.ToString());
            MyTab.SelectedIndex = 1;
        }
    }
}
