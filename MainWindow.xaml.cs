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

namespace Gallows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            DrawHangPost();
        }

        private void DrawHangPost()
        {
            Line line1 = new Line();
            line1.Stroke = Brushes.SaddleBrown;
            line1.StrokeThickness = 10;
            line1.X1 = 120;
            line1.Y1 = 215;
            line1.X2 = 120;
            line1.Y2 = 5;

            Line line2 = new Line();
            line2.Stroke = Brushes.SaddleBrown;
            line2.StrokeThickness = 10;
            line2.X1 = 120;
            line2.Y1 = 10;
            line2.X2 = 50;
            line2.Y2 = 10;

            Line line3 = new Line();
            line3.Stroke = Brushes.SaddleBrown;
            line3.StrokeThickness = 10;
            line3.X1 = 55;
            line3.Y1 = 10;
            line3.X2 = 55;
            line3.Y2 = 60;

            canvas1.Children.Add(line1);
            canvas1.Children.Add(line2);
            canvas1.Children.Add(line3);
        }
    }
}
