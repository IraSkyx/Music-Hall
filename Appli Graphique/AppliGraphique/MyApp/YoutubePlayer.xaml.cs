using Biblio;
using Gecko;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour YoutubePlayer.xaml
    /// </summary>
    public partial class YoutubePlayer : System.Windows.Controls.UserControl
    {
        public GeckoWebBrowser Browser = new GeckoWebBrowser { Dock = DockStyle.Fill};

        /// <summary>
        /// Initialise YoutubePlayer
        /// </summary>
        public YoutubePlayer()
        {
            InitializeComponent();
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate () { Init(); });
            Browser.CreateWindow += new EventHandler<GeckoCreateWindowEventArgs>(myEvent);
        }

        /// <summary>
        /// Initialise la taille de la nouvelle page créé
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par le UserControl </param>
        private void myEvent(object sender, GeckoCreateWindowEventArgs e)
        {
            e.InitialHeight = 400;
            e.InitialWidth = 800;
        }

        /// <summary>
        /// Initialise les fichiers du moteur GeckoFX et celui-ci dans le UserControl
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par le UserControl </param>
        [STAThread]
        public void Init()
        {
            PersistanceMusics.SetCurrentDirectory(Directory.GetParent((Directory.GetParent((Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))).FullName)).FullName);
            if (!Directory.Exists("Firefox") || Directory.EnumerateFileSystemEntries("Firefox").Count() != 20)
            {
                if (Directory.Exists("Firefox"))
                    Directory.Delete("Firefox", true);
                Directory.CreateDirectory("Firefox");
                ZipFile.ExtractToDirectory("Firefox.zip", "Firefox");
            }
            Xpcom.Initialize("Firefox");
            Host.Child = Browser;
            PersistanceMusics.SetCurrentDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MusicHall"));
        }
    }
}
