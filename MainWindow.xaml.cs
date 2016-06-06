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
            //DrawBodyPart(BodyParts.HEAD);
            //DrawBodyPart(BodyParts.LEFTEYE);
            //DrawBodyPart(BodyParts.RIGHTEYE);
            //DrawBodyPart(BodyParts.MOUTH);
        }

        enum BodyParts
        {
            HEAD, LEFTEYE, RIGHTEYE, MOUTH, BODY, LEFTARM, RIGHTARM, LEFTLEG, RIGHTLEG  
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

        private void DrawBodyPart(BodyParts part)
        {
            switch (part)
            {
                case BodyParts.HEAD:
                    Ellipse head = new Ellipse();
                    head.Stroke = Brushes.Black;
                    head.Width = 40;
                    head.Height = 40;
                    head.Margin = new Thickness(35, 60, 0, 0);
                    canvas1.Children.Add(head);
                    break;
                case BodyParts.BODY:
                    break;
                case BodyParts.LEFTARM:
                    break;
                case BodyParts.RIGHTARM:
                    break;
                case BodyParts.LEFTLEG:
                    break;
                case BodyParts.RIGHTLEG:
                    break;
                case BodyParts.LEFTEYE:
                    Ellipse lEye = new Ellipse();
                    lEye.Stroke = Brushes.Black;
                    lEye.Fill = Brushes.Black;
                    lEye.Width = 5;
                    lEye.Height = 5;
                    lEye.Margin = new Thickness(45, 72, 0, 0);
                    canvas1.Children.Add(lEye);
                    break;
                case BodyParts.RIGHTEYE:
                    Ellipse rEye = new Ellipse();
                    rEye.Stroke = Brushes.Black;
                    rEye.Fill = Brushes.Black;
                    rEye.Width = 5;
                    rEye.Height = 5;
                    rEye.Margin = new Thickness(60, 72, 0, 0);
                    canvas1.Children.Add(rEye);
                    break;
                case BodyParts.MOUTH:
                    Ellipse mouth = new Ellipse();
                    mouth.Stroke = Brushes.Black;
                    mouth.Width = 20;
                    mouth.Height = 20;
                    mouth.Clip = new RectangleGeometry(new Rect(0, 0, mouth.Width, mouth.Height / 2));
                    mouth.Margin = new Thickness(45, 82, 0, 0);
                    canvas1.Children.Add(mouth);
                    break;                    
            }
        }
    }
}
