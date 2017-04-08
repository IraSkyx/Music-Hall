using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WMPLib;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WindowsMediaPlayer player = new WindowsMediaPlayer();
        public DispatcherTimer myTimer;
        int CurrentSecond=0;
        int CurrentTimer=0;
        int duree = 210;

        public MainWindow()
        {
            InitializeComponent();

            // zik = new Musique("Back For More", "Feder feat Daecom","blablabla", @"..\resources\eFeder.jpg", "06/04/2017", @"C:\Users\Adrien\Desktop\C#\Appli Graphique\AppliGraphique\resources\Feder.mp3", 210);

            //MyMusics db = new MyMusics(@"C:\Users\Adrien\Desktop\C#\Appli Graphique\AppliGraphique\MyMusics.mdf");
            //db.CreateDatabase();

            myTimer = new DispatcherTimer();
            myTimer.Tick += new EventHandler(MyEvent);
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);

            Thread Thread = new Thread(new ThreadStart(ThreadLoop));      
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Increase(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                increase.Content = "+";
            }
            else
            {
                WindowState = WindowState.Maximized;
                increase.Content = "-";
            }
        }

        private void Connexion(object sender, RoutedEventArgs e)
        {
            Window1 subWindow = new Window1();
            subWindow.Show();
        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            Window2 subWindow2 = new Window2();
            subWindow2.Show();
        }

        public static void ThreadLoop()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(500);
            }
        }

        private void MyEvent(object sender, EventArgs e)
        {
            if (CurrentTimer == 4)
            {
                
                ++CurrentSecond;                
                duration.Content = (CurrentSecond/60).ToString("00") + ":" + (CurrentSecond % 60).ToString("00");
                CurrentTimer = 0;
            }
            ++CurrentTimer;
            Prog.Value = ((CurrentSecond+(CurrentTimer*0.25)) * 100) / duree;
        }

        private void Play(object sender, RoutedEventArgs e)
        {
                player.URL = @"C:\Users\Adrien\Desktop\C#\Appli Graphique\AppliGraphique\resources\Feder.mp3";
                player.settings.volume = 50;
                player.controls.play();
                myTimer.Start();
        }

        private void Replay(object sender, RoutedEventArgs e)
        {
            if (player == null)
            {
                return;
            }
            player.settings.setMode("Loop", true);
        }

        private void Pause(object sender, RoutedEventArgs e)
        {
            if (player == null)
            {
                return;
            }
            if (myTimer.IsEnabled)
            {           
                player.controls.pause();
                myTimer.Stop();
            }
        }

        private void Change(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.settings.volume = Convert.ToInt32(slider.Value);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
