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
        public GeckoWebBrowser geckoWebBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };

        public YoutubePlayer()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {            
            PersistanceMusics.SetCurrentDirectory(Directory.GetParent((Directory.GetParent((Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))).FullName)).FullName);
            if (!Directory.Exists("Firefox") || !Directory.EnumerateFileSystemEntries("Firefox").Any())
            {
                Directory.CreateDirectory("Firefox");
                ZipFile.ExtractToDirectory("Firefox.zip", "Firefox");
            }                
            Xpcom.Initialize("Firefox");           
            Host.Child = geckoWebBrowser;
            PersistanceMusics.SetCurrentDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MusicHall"));
        }
    }
}
