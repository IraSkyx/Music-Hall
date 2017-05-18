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
        private Lecteur MyPlayer = ((Lecteur)Application.Current.MainWindow.FindName("MyPlayer"));
        private ListView MyScroller = ((ListView)Application.Current.MainWindow.FindName("MyScroller"));

        /// <summary>
        /// Instancie Selection
        /// </summary>
        public Selection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Joue le son actuellement selectionné par le Scroller
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void PlayASong(object sender, RoutedEventArgs e)
            => MyPlayer.Player.Play((IMusic)MyScroller.SelectedItem);

        /// <summary>
        /// Ajotue la Music à la Playlist, gère les différents cas de figures (Exemple : si la playlist n'est pas encore instancié)
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (!ReferenceEquals(MyPlayer.Player.CurrentUser,null))
            {
                if (!ReferenceEquals(MyPlayer.Player.CurrentUser.Favorite,null))
                {
                    if (MyPlayer.Player.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals((IMusic)MyScroller.SelectedItem)) == 0)
                        MyPlayer.Player.CurrentUser.Favorite.PlaylistProperty.Add(ReferenceEquals(MyPlayer.Add1, sender) ? MyPlayer.Player.CurrentlyPlaying : (IMusic)MyScroller.SelectedItem);
                }
                else
                {
                    MyPlayer.Player.CurrentUser.Favorite = new Playlist();
                    MyPlayer.Player.CurrentUser.Favorite.PlaylistProperty.Add(ReferenceEquals(MyPlayer.Add1, sender) ? MyPlayer.Player.CurrentlyPlaying : (IMusic)MyScroller.SelectedItem);
                }
            }
            MyPlayer.Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }
    }
}
