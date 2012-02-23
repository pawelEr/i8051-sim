using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace symulator8051
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            clockRateSlider.Value = Sets.Commands;
            clockRateTbox.Text = (Sets.Commands).ToString() + " hz";
            refreshRateSlider.Value = Sets.Sleep;
            refreshRateTbox.Text = Sets.Sleep.ToString() + " ms";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sets.Commands =Convert.ToInt32(clockRateSlider.Value);
            Sets.Sleep = Convert.ToInt32(refreshRateSlider.Value);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clockRateSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(clockRateTbox!=null)
                clockRateTbox.Text = Convert.ToInt32(clockRateSlider.Value).ToString()+" hz";
        }

        private void refreshRateSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(refreshRateTbox!=null)
                refreshRateTbox.Text = Convert.ToInt32(refreshRateSlider.Value).ToString();
        }
    }
}
