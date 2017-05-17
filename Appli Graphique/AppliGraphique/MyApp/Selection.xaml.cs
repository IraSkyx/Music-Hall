using Biblio;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Selection.xaml
    /// </summary>
    public partial class Selection : UserControl
    {
        private Lecteur lecteur = ((Lecteur)Application.Current.MainWindow.FindName("lecteur"));
        private ListView scroller = ((ListView)Application.Current.MainWindow.FindName("scroller"));

        public Selection()
            => InitializeComponent();

        private void PlayASong(object sender, RoutedEventArgs e)
            => lecteur.Player.Play((IMusic)scroller.SelectedItem);

        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (!ReferenceEquals(lecteur.Player.CurrentUser,null))
            {
                if (!ReferenceEquals(lecteur.Player.CurrentUser.Favorite,null))
                {
                    if (lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals((IMusic)scroller.SelectedItem)) == 0)
                        lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Add(lecteur.Add1 == sender ? lecteur.Player.CurrentlyPlaying : (IMusic)scroller.SelectedItem);
                }
                else
                {
                    lecteur.Player.CurrentUser.Favorite = new Playlist();
                    lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Add(lecteur.Add1 == sender ? lecteur.Player.CurrentlyPlaying : (IMusic)scroller.SelectedItem);
                }
            }
            lecteur.Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }
    }
}
