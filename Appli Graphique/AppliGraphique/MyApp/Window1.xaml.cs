using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyApp
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                Canvas.SetLeft(this, SystemParameters.PrimaryScreenWidth / 2 - 540);
                Canvas.SetTop(this, SystemParameters.PrimaryScreenHeight / 2 - 360);
                increase.Content = "+";
            }
        }
    }
}
