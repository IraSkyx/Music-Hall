using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour SongDetail.xaml
    /// </summary>
    public partial class SongDetail : UserControl
    {
        public Thread myThread;
        private LinkedList<ProgressBar> MyProgs = new LinkedList<ProgressBar>();
        private int[] Previous = new int[30];

        /// <summary>
        /// Instancie SongDetail
        /// </summary>
        public SongDetail()
        {
            InitializeComponent();

            InitializeProgressBar();

            Task t = Task.Run(() => SetValues());
        }

        /// <summary>
        /// Initialise les Progress Bar
        /// </summary>
        private void InitializeProgressBar()
        {
            for (int i = 0; i < 30; ++i)
            {
                ProgressBar bar = new ProgressBar()
                {
                    Maximum = 100,
                    Minimum = 0,
                    Margin = new Thickness(0, 1, 0, 1),
                    Background = Brushes.Transparent,
                    Foreground = new SolidColorBrush(Color.FromRgb(23, 23, 23)),
                    BorderThickness = new Thickness(0)

                };
                BindingOperations.SetBinding(bar, HeightProperty, new Binding()
                {
                    Path = new PropertyPath("ActualWidth"),
                    Converter = new ValueToContent(),
                    ConverterParameter= "scale"
                });
                MyProgs.AddFirst(bar);
                ProgGrid.Children.Add(bar);
            }
        }

        /// <summary>
        /// Modifie les valeurs des Progress Bar en fonction du MasterPeakValue de Naudio.dll en Multi-Threadé
        /// </summary>
        [MTAThread]
        public void SetValues()
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
                                    if (ReferenceEquals(Application.Current.MainWindow,null))
                                        return;
                                    (MyProgs.ElementAt(i)).Value = RoundedValue * 0.50 + Previous[i] / 3 + r.Next(0, 10);
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
                                    if (ReferenceEquals(Application.Current.MainWindow, null))
                                        return;
                                    (MyProgs.ElementAt(i)).Value = 0;
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