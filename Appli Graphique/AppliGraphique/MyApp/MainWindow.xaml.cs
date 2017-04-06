using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
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
using WMPLib;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Musique zik;
        WindowsMediaPlayer player = null;
        Timer myTimer;
        int CurrentSecond;
        int CurrentMinute;
        int CurrentHour;

        public MainWindow()
        {
            InitializeComponent();
            zik = new Musique("Back For More", "Feder feat Daecom","blablabla", @"C:\Users\adria\Desktop\eFeder.jpg", "06/04/2017", @"C:\Users\adria\Desktop\Feder feat. Daecolm - Back For More.mp3", 210);
            myTimer = new Timer(1000);
            myTimer.Enabled = true;
            myTimer.Elapsed += new ElapsedEventHandler(myEvent);        
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void Increase(object sender, RoutedEventArgs e)
        {
            if ((string)increase.Content == "+")
            {
                Width = SystemParameters.PrimaryScreenWidth;
                Height = SystemParameters.PrimaryScreenHeight;
                Canvas.SetTop(this, 0);
                Canvas.SetLeft(this, 0);
                increase.Content = "-";
            }
            else
            {               
                Width = 1080;
                Height = 720;
                Canvas.SetLeft(this,SystemParameters.PrimaryScreenWidth / 2 - 540);
                Canvas.SetTop(this, SystemParameters.PrimaryScreenHeight / 2 - 360);
                increase.Content = "+";
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

        private void myEvent(object sender, ElapsedEventArgs e)
        {
            duration.Content = 1;
            while (CurrentSecond* CurrentMinute*CurrentHour<zik.duree) {
                ++CurrentSecond;
                if (CurrentSecond == 60)
                {
                    CurrentSecond = 0;
                    ++CurrentMinute;
                }
                if (CurrentMinute == 60)
                {
                    CurrentMinute = 0;
                    ++CurrentHour;
                }
                duration.Content = CurrentSecond + ":" + CurrentMinute + ":" + CurrentHour;
            }
        }

        private void Play(object sender, RoutedEventArgs e)
        {
                CurrentSecond = 0;
                CurrentMinute = 0;
                CurrentHour = 0;
                player = new WindowsMediaPlayer();
                player.URL = zik.audio;
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
            if (myTimer.Enabled == true)
            {
                myTimer.Enabled = false;               
                player.controls.pause();
            }
        }

        private void Change(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.settings.volume = Convert.ToInt32(slider.Value*100);
        }
    }
}
