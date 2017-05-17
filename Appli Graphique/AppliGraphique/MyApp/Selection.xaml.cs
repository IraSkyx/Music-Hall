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
        {
            InitializeComponent();
        }

        private void PlayASong(object sender, RoutedEventArgs e)
            => lecteur.Player.Play((IMusic)scroller.SelectedItem);

        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (lecteur.Player.CurrentUser != null)  //Si un user est connecté
            {
                if (lecteur.Player.CurrentUser.Favorite != null) //Si l'utilisateur a une playlist
                {
                    if (lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals((IMusic)scroller.SelectedItem)) == 0) //Si la musique est déjà dans sa playlist
                        lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Add(lecteur.Add1 == sender ? lecteur.Player.CurrentlyPlaying : (IMusic)scroller.SelectedItem);
                }
                else //Si l'utilisateur n'a pas de playlist
                {
                    lecteur.Player.CurrentUser.Favorite = new Playlist();
                    lecteur.Player.CurrentUser.Favorite.PlaylistProperty.Add(lecteur.Add1 == sender ? lecteur.Player.CurrentlyPlaying : (IMusic)scroller.SelectedItem);
                }
            }
            lecteur.Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }
    }
}
