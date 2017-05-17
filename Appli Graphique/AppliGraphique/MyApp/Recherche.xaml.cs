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

        private void ResultSelectionChanged(object sender, SelectionChangedEventArgs e)
            => ((ListView)Application.Current.MainWindow.FindName("MyScroller")).SelectedItem = Search.SelectedItem;

        private void UserInputChanged(object sender, TextChangedEventArgs e)
        {
            if (Input.Text != String.Empty)
                Search.DataContext = ((Lecteur)Application.Current.MainWindow.FindName("MyPlayer")).Allmusics.Filter((string)((ComboBoxItem)Criterion.SelectedItem).Content, Input.Text);
        }

        private void Criterion_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => UserInputChanged(this, new TextChangedEventArgs(e.RoutedEvent, UndoAction.None));
    }
}
