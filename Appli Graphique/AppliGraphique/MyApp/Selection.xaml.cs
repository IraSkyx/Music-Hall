using Biblio;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Selection.xaml
    /// </summary>
    public partial class Selection : UserControl
    {
        public static readonly DependencyProperty Player = DependencyProperty.Register("MyPlayer", typeof(Lecteur), typeof(Selection));
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

        public static readonly DependencyProperty Scroller = DependencyProperty.Register("MyScroller", typeof(ListView), typeof(Selection));
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
                if (MyPlayer.Player.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals((IMusic)MyScroller.SelectedItem)) == 0)
                    MyPlayer.Player.CurrentUser.Favorite.PlaylistProperty.Add(ReferenceEquals(MyPlayer.Add1, sender) ? MyPlayer.Player.CurrentlyPlaying : (IMusic)MyScroller.SelectedItem);
            }
            MyPlayer.Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Profil subWindow3 = new Profil(MyPlayer.Player.CurrentUser, AllUsers)
            //AddComment adcom = new AddComment (AllComment, MyPlayer.Player.CurrentUser);
            //adcom.ShowDialog();
        }
    }
}
