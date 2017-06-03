using Biblio;
using NAudio.CoreAudioApi;
using System;
using System.Linq;
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
        private Thread myThread;
        private Equalizer MyEqualizer = new Equalizer(30);
        private int[] Previous = new int[30];

        /// <summary>
        /// Instancie SongDetail
        /// </summary>
        public SongDetail()
        {
            InitializeComponent();

            InitializeEqualizer();

            Task t = Task.Run(() => SetValues());
        }

        /// <summary>
        /// Initialise les Progress Bar
        /// </summary>
        private void InitializeEqualizer()
        {
            for (int i = 0; i < 30; ++i)
            {                
                ProgGrid.Children.Add(MyEqualizer.MyProgs.ElementAt(i).Value);
            }
        }

        /// <summary>
        /// Modifie les valeurs des Progress Bar en fonction du MasterPeakValue de Naudio.dll en Multi-Threadé
        /// </summary>
        [MTAThread]
        private void SetValues()
        {
            MMDevice DefaultDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            float BaseValue;
            double RoundedValue;
            Random r = new Random();

            myThread = new Thread(() =>
            {
                while (Thread.CurrentThread.IsAlive)
                {
                    for (int i = 0; i < 30; ++i)
                    {
                        BaseValue = DefaultDevice.AudioMeterInformation.MasterPeakValue;
                        RoundedValue = Math.Round(BaseValue * 100);
                        if (BaseValue > 0)
                        {
                            try
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    MyEqualizer.MyProgs.ElementAt(i).Value.Value = RoundedValue * 0.50 + Previous[i] / 3 + r.Next(0, 10);
                                    Previous[i] = Convert.ToInt32(RoundedValue);
                                });
                            }
                            catch (NullReferenceException) { myThread = null; return; }
                        }
                        else
                        {
                            try
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    MyEqualizer.MyProgs.ElementAt(i).Value.Value = 0;
                                    Previous[i] = Convert.ToInt32(RoundedValue);
                                });
                            }
                            catch (NullReferenceException) { myThread = null; return; }
                        }
                        Thread.Sleep(1);
                    }
                }
            });
            myThread.Start();
        }
    }
}