using NAudio.CoreAudioApi;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour SongDetail.xaml
    /// </summary>
    public partial class SongDetail : UserControl
    {
        public Thread myThread;

        public SongDetail()
        {
            InitializeComponent();
            Task t = Task.Run(() => SetValues());
        }

        [MTAThread]
        public void SetValues()
        {
            MMDevice DefaultDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            float BaseValue;
            double RoundedValue;
            double previous = 0;
            Random r = new Random();

            myThread = new Thread(() =>
            {
                while (Thread.CurrentThread.IsAlive)
                {
                    for (int i = 1; i < 31; ++i)
                    {
                        BaseValue = DefaultDevice.AudioMeterInformation.MasterPeakValue;
                        RoundedValue = Math.Round(BaseValue * 100);                        

                        if (BaseValue > 0)
                        {
                            try
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    if (Application.Current.MainWindow == null)
                                        return;
                                    ((ProgressBar)(((Lecteur)Application.Current.MainWindow.FindName("lecteur")).Detail1.FindName("Prog" + i))).Value = RoundedValue + previous / 3 + r.Next(5, 15) > 100 ? 100 : RoundedValue + previous / 3 + r.Next(5, 15);
                                });
                            }
                            catch (NullReferenceException)
                            {
                                myThread = null;
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    for (int j = 1; j < 31; ++j)
                                        ((ProgressBar)(((Lecteur)Application.Current.MainWindow.FindName("lecteur")).Detail1.FindName("Prog" + j))).Value = 0;
                                });
                            }                               
                            catch (NullReferenceException)
                            {
                                myThread = null;
                                return;
                            }
                        }
                        if (i == 1)
                            previous = RoundedValue;
                        Thread.Sleep(2);
                    }                   
                }
            });
            myThread.Start();
        }
    }
}