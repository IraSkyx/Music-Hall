using NAudio.CoreAudioApi;
using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour SongDetail.xaml
    /// </summary>
    public partial class SongDetail : UserControl
    {
        private MMDevice defaultDevice { get; set; }

        public SongDetail()
        {
            InitializeComponent();

            defaultDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += new EventHandler(myEvent);
            timer.Start();
        }

        private void myEvent(object sender, EventArgs e)
        {
            if (defaultDevice.AudioMeterInformation.MasterPeakValue * 100 > 0)
            {
                Random r = new Random();
                Prog1.Value = (int)(Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue * 100)) + r.Next(0, (int)(100 - Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue)) / 2);
                Prog2.Value = (int)(Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue * 100)) + r.Next(0, (int)(100 - Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue)) / 2);
                Prog3.Value = (int)(Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue * 100)) + r.Next(0, (int)(100 - Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue)) / 2);
                Prog4.Value = (int)(Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue * 100)) + r.Next(0, (int)(100 - Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue)) / 2);
                Prog5.Value = (int)(Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue * 100)) + r.Next(0, (int)(100 - Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue)) / 2);
                Prog6.Value = (int)(Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue * 100)) + r.Next(0, (int)(100 - Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue)) / 2);
                Prog7.Value = (int)(Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue * 100)) + r.Next(0, (int)(100 - Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue)) / 2);
                Prog8.Value = (int)(Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue * 100)) + r.Next(0, (int)(100 - Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue)) / 2);
                Prog9.Value = (int)(Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue * 100)) + r.Next(0, (int)(100 - Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue)) / 2);
                Prog10.Value = (int)(Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue * 100)) + r.Next(0, (int)(100 - Math.Round(defaultDevice.AudioMeterInformation.MasterPeakValue)) / 2);
            }
            else
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
            }
        }
    }
}
