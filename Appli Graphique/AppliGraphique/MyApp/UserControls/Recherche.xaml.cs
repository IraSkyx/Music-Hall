using BackEnd;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Recherche.xaml
    /// </summary>
    public partial class Recherche : UserControl
    {
        /// <summary>
        /// DependencyProperty vers MyScroller de MainWindow.xaml
        /// </summary>
        public static readonly DependencyProperty Scroller = DependencyProperty.Register("MyScroller", typeof(ListView), typeof(Recherche));
        /// <summary>
        /// Propriété contenant les valeurs de la DependencyProperty "Scroller"
        /// </summary>
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

        /// <summary>
        /// DependencyProperty vers MyTab de MainWindow.xaml
        /// </summary>
        public static readonly DependencyProperty Tab = DependencyProperty.Register("MyTab", typeof(TabControl), typeof(Recherche));
        /// <summary>
        /// Propriété contenant les valeurs de la DependencyProperty "Tab"
        /// </summary>
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

        /// <summary>
        /// Instancie Recherche
        /// </summary>
        public Recherche()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Change la sélection de MyScroller en fonction de la sélection par l'User dans la liste de résultats 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void ResultSelectionChanged(object sender, SelectionChangedEventArgs e)
            => MyScroller.SelectedItem = Search.SelectedItem;

        /// <summary>
        /// Change le DataContext par le résultat de la fonction <code>Filter()</code> de Playlist 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void UserInputChanged(object sender, TextChangedEventArgs e)
        {
            if (Input.Text != String.Empty)
                Search.DataContext = PlaylistFront.AllMusics.Filter((string)((ComboBoxItem)Criterion.SelectedItem).Content, Input.Text);
        }

        /// <summary>
        /// Lève manuellement <code>UserInputChanged()</code>
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void CriterionChanged(object sender, SelectionChangedEventArgs e)
            => UserInputChanged(this, new TextChangedEventArgs(e.RoutedEvent, UndoAction.None));
    }
}