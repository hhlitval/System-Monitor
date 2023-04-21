using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
    /// Interaction logic for Gauge.xaml
    /// </summary>
    public partial class Gauge : UserControl
    {
        public Gauge()
        {
            InitializeComponent();
        }
        public Color Foreground1
        {
            get { return (Color)GetValue(Foreground1Property); }
            set { SetValue(Foreground1Property, value); }
        }

        public static readonly DependencyProperty Foreground1Property = DependencyProperty.Register("Foreground1", typeof(Color), typeof(Gauge));

        public Color Foreground2
        {
            get { return (Color)GetValue(Foreground2Property); }
            set { SetValue(Foreground2Property, value); }
        }

        public static readonly DependencyProperty Foreground2Property = DependencyProperty.Register("Foreground2", typeof(Color), typeof(Gauge));

        public string Radius
        {
            get { return (string)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(string), typeof(Gauge));

    }
}
