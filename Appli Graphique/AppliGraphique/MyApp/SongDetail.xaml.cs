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
            Task.Run(() => SetValues());
        }

        [MTAThread]
        public void SetValues()
        {
            MMDevice DefaultDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            float BaseValue;
            double RoundedValue;
            int MaxAddedValue;
            Random r = new Random();

             myThread = new Thread(() =>
            {
                while (Thread.CurrentThread.IsAlive)
                {
                    BaseValue = DefaultDevice.AudioMeterInformation.MasterPeakValue;
                    RoundedValue = Math.Round(BaseValue * 100);                        
                    MaxAddedValue = (int)(100 - RoundedValue);

                    if (BaseValue > 0)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Prog1.Value = RoundedValue + r.Next(MaxAddedValue / 4, MaxAddedValue/2);
                            Prog2.Value = RoundedValue + r.Next(MaxAddedValue / 4, MaxAddedValue/2);
                            Prog3.Value = RoundedValue + r.Next(MaxAddedValue / 4, MaxAddedValue/2);
                            Prog4.Value = RoundedValue + r.Next(MaxAddedValue / 4, MaxAddedValue/2);
                            Prog5.Value = RoundedValue + r.Next(MaxAddedValue / 4, MaxAddedValue/2);
                            Prog6.Value = RoundedValue + r.Next(MaxAddedValue / 4, MaxAddedValue/2);
                            Prog7.Value = RoundedValue + r.Next(MaxAddedValue / 4, MaxAddedValue/2);
                            Prog8.Value = RoundedValue + r.Next(MaxAddedValue / 4, MaxAddedValue/2);
                            Prog9.Value = RoundedValue + r.Next(MaxAddedValue / 4, MaxAddedValue/2);
                            Prog10.Value = RoundedValue + r.Next(MaxAddedValue / 4, MaxAddedValue/2);
                        });
                    }
                    else
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Prog1.Value = 0;
                            Prog2.Value = 0;
                            Prog3.Value = 0;
                            Prog4.Value = 0;
                            Prog5.Value = 0;
                            Prog6.Value = 0;
                            Prog7.Value = 0;
                            Prog8.Value = 0;
                            Prog9.Value = 0;
                            Prog10.Value = 0;
                        });
                    }
                    Thread.Sleep(70);
                }
            });
            myThread.Start();
        }
    }
}