using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        public string url = @"C:\Users\adria\Desktop\C#\Appli Graphique\AppliGraphique\resources\Feder.mp3";
        public double time=0.00;
        Util View = new Util();

        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = View;
            myTimer = new DispatcherTimer();
            myTimer.Tick += new EventHandler(MyEvent);
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            player.settings.volume = 50;           
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
                increase.Content = "⇱";
            }
            else
            {
                WindowState = WindowState.Maximized;
                increase.Content = "⇲";
            }
        }

        private void Connexion(object sender, RoutedEventArgs e)
        {
            Window1 subWindow = new Window1();
            subWindow.Show();
        }

        private void Reduce(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            Window2 subWindow2 = new Window2();
            subWindow2.Show();
        }

        private void MyEvent(object sender, EventArgs e)
        {
            duration.Content = (Math.Floor(player.controls.currentPosition / 60)).ToString("00") + ":" + (player.controls.currentPosition % 60).ToString("00");
            if(player.currentMedia.duration != 0)
            {
                Prog.Value = (player.controls.currentPosition * 100) / player.currentMedia.duration;
            }
        }

        private void Replay(object sender, RoutedEventArgs e)
        {
            if (player.settings.getMode("Loop"))
            {
                player.settings.setMode("Loop", false);
                replay.Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));
            }
            else
            {
                player.settings.setMode("Loop", true);
                replay.Foreground = new SolidColorBrush(Color.FromRgb(39, 174, 96));
            }
        }

        private void PlayPause(object sender, RoutedEventArgs e)
        {
            if ((string)PausePlay.Content == "▶")
            {
                player.URL = url;
                player.controls.currentPosition = time;
                PausePlay.Content = "∥";
                PausePlay.ToolTip = "Pause";
                player.controls.play();
                myTimer.Start();
            } 
            else
            {
                time = player.controls.currentPosition;
                player.controls.pause();
                PausePlay.Content = "▶";
                PausePlay.ToolTip = "Lecture";
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

    internal class Util
    {
        public ObservableCollection<Musique> li = new ObservableCollection<Musique>();

        internal ObservableCollection<Musique> ChargerMusic()
        {
            string [] line = new string[6];          
            try
            {
                using (StreamReader str = new StreamReader(@"C:\Users\adria\Desktop\C#\Appli Graphique\AppliGraphique\resources\File.txt"))
                {
                    while (str.EndOfStream==false)
                    {
                        for(int i = 0; i <=5 ; ++i)
                        {
                            line[i] = str.ReadLine();
                        }
                        li.Add(new Musique(line[0], line[1], line[2], line[3], line[4], line[5]));
                    }
                }               
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return li;
        }
    }
}
