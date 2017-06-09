using Biblio;
using NAudio.CoreAudioApi;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Controls;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour SongDetail.xaml
    /// </summary>
    public partial class SongDetail : UserControl
    {
        private Equalizer MyEqualizer = new Equalizer(30);
        private int[] Previous = new int[30];
        private Random r = new Random();
        public BackgroundWorker MyWorker = new BackgroundWorker()
        {
            WorkerSupportsCancellation = true
        };
        private float BaseValue;
        private double RoundedValue;

        /// <summary>
        /// Instancie SongDetail
        /// </summary>
        public SongDetail()
        {
            InitializeComponent();

            InitializeEqualizer();

            MyWorker.DoWork += new DoWorkEventHandler(SetValues);
            MyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkCompleted);
            MyWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Ajoute les Progress Bar à la vue
        /// </summary>
        private void InitializeEqualizer()
        {
            for (int i = 0; i < 30; ++i)          
                ProgGrid.Children.Add(MyEqualizer.MyProgs.ElementAt(i).Value);
        }

        /// <summary>
        /// Relance le Worker
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par le worker </param>
        private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)         
            => MyWorker.RunWorkerAsync();

        /// <summary>
        /// Modifie les valeurs des Progress Bar en fonction du MasterPeakValue de Naudio.dll
        /// </summary>
        /// <param name="sender"> Object envoyeur </param>
        /// <param name="e"> Évènement déclenché par le worker </param>
        private void SetValues(object sender, DoWorkEventArgs e)
        {
            MMDevice DefaultDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);    
            for (int i = 0; i < 30; ++i)
            {
                if (MyWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                BaseValue = DefaultDevice.AudioMeterInformation.MasterPeakValue;
                RoundedValue = Math.Round(BaseValue * 100);                

                if (RoundedValue > 0)
                {
                    Dispatcher.Invoke(() =>
                    {
                        MyEqualizer.MyProgs.ElementAt(i).Value.Value = RoundedValue * 0.50 + Previous[i] / 3 + r.Next(0, 10);
                        Previous[i] = Convert.ToInt32(RoundedValue);
                    });
                }
                else
                {
                    Dispatcher.Invoke(() =>
                    {
                        MyEqualizer.MyProgs.ElementAt(i).Value.Value = 0;
                        Previous[i] = Convert.ToInt32(RoundedValue);
                    });
                }
                Thread.Sleep(1);
            }
        }
    }
}