using LiveCharts.Wpf;
using LiveCharts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace System_Monitor.UserControls
{
    /// <summary>
    /// Interaction logic for LineChart.xaml
    /// </summary>
    public partial class LineChart : UserControl
    {
        public LineChart()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Weight =",
                    Values = new ChartValues<double> {0.0, 2.4, 3.5, 2.1, 7.6, 10.5, 20.4, 12.1, 4.6, 1.5, 2.8, 2.0, 6.6, 1.5, 15.2, 22.1}
                },
            };

            Labels = new[] { "1 Mar", "2 Mar", "3 Mar", "4 Mar", "5 Mar", "6 Mar", "7 Mar",
            "8 Mar","9 Mar","10 Mar","11 Mar","12 Mar","13 Mar","14 Mar","15 Mar","16 Mar"};
            YFormatter = value => value.ToString("N1");
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
}
