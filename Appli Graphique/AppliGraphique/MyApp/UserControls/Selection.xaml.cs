using Biblio;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using BackEnd;
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
            => PlayerFront.MyPlayer.Play((IMusic)DataContext);

        /// <summary>
        /// Ajoute la Music à la Playlist si un User est connecté
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            if (!ReferenceEquals(PlayerFront.MyPlayer.CurrentUser,null))
            {
                if (PlayerFront.MyPlayer.CurrentUser.Favorite.PlaylistProperty.Count(x => x.Equals((IMusic)MyScroller.SelectedItem)) == 0)
                    PlayerFront.MyPlayer.CurrentUser.Favorite.PlaylistProperty.Add(ReferenceEquals(MyPlayer.Add1, sender) ? PlayerFront.MyPlayer.CurrentlyPlaying : (IMusic)DataContext);
            }
            MyPlayer.Add1.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }

        /// <summary>
        /// Ajoute un Comment à la Music si un User est connecté 
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par la vue </param>
        private void AddComment(object sender, RoutedEventArgs e)
        {
            if (!ReferenceEquals(PlayerFront.MyPlayer.CurrentUser, null))
            {
                AddComment adcom = new AddComment(PlayerFront.MyPlayer.CurrentUser.Username)
                {
                    DataContext = (IMusic)DataContext
                };        
                adcom.ShowDialog();
            }
           
        }
    }
}
