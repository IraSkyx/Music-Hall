using Biblio;
using Gecko;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour YoutubePlayer.xaml
    /// </summary>
    public partial class YoutubePlayer : System.Windows.Controls.UserControl
    {
        public GeckoWebBrowser Browser = new GeckoWebBrowser { Dock = DockStyle.Fill };

        public YoutubePlayer()
        {
            InitializeComponent();
            Init();
            Browser.CreateWindow += new EventHandler<GeckoCreateWindowEventArgs>(myEvent);
        }

        private void myEvent(object sender, GeckoCreateWindowEventArgs e)
        {
            e.InitialHeight = 400;
            e.InitialWidth = 800;
        }

        private void Init()
        {
            PersistanceMusics.SetCurrentDirectory(Directory.GetParent((Directory.GetParent((Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))).FullName)).FullName);
            if (!Directory.Exists("Firefox") || Directory.EnumerateFileSystemEntries("Firefox").Count() != 20)
            {
                if(Directory.Exists("Firefox"))
                    Directory.Delete("Firefox");
                Directory.CreateDirectory("Firefox");
                ZipFile.ExtractToDirectory("Firefox.zip", "Firefox");
            }
            Console.WriteLine(Directory.GetCurrentDirectory());
            Xpcom.Initialize("Firefox");
            Host.Child = Browser;
            PersistanceMusics.SetCurrentDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MusicHall"));
        }
    }
}
