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
        public Recherche()
        {
            InitializeComponent();
        }

        private void Search_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => ((ListView)Application.Current.MainWindow.FindName("scroller")).SelectedItem = Search.SelectedItem;

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Input.Text != String.Empty)
                Search.DataContext = ((Lecteur)Application.Current.MainWindow.FindName("lecteur")).Allmusics.Filter((string)((ComboBoxItem)Criterion.SelectedItem).Content, Input.Text);
        }

        private void Criterion_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => Input_TextChanged(this, new TextChangedEventArgs(e.RoutedEvent, UndoAction.None));
    }
}
