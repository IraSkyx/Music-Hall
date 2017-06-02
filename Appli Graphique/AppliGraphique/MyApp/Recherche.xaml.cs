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

        public static readonly DependencyProperty Scroller = DependencyProperty.Register("MyScroller", typeof(ListView), typeof(Recherche));
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
        /// Change le DataContext par le résultat de la fonction <code>Filter()</code> de Playlist 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void CriterionChanged(object sender, SelectionChangedEventArgs e)
            => UserInputChanged(this, new TextChangedEventArgs(e.RoutedEvent, UndoAction.None));
    }
}
