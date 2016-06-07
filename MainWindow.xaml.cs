using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

/// <summary>
/// Gallows by Gerald Soriano
/// Date: 06/05/2016
/// </summary>
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
            WordGenerator wordGen = new WordGenerator();
            Dispatcher.BeginInvoke((Action)(() => {
                wordGen.GenerateWord();
                MessageBox.Show(wordGen.Word);
            }));
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
                    Line body = new Line();
                    body.Stroke = Brushes.Black;
                    body.X1 = 55;
                    body.Y1 = 100;
                    body.X2 = 55;
                    body.Y2 = 170;
                    canvas1.Children.Add(body);
                    break;
                case BodyParts.LEFTARM:
                    Line lArm = new Line();
                    lArm.Stroke = Brushes.Black;
                    lArm.X1 = 55;
                    lArm.Y1 = 110;
                    lArm.X2 = 25;
                    lArm.Y2 = 140;
                    canvas1.Children.Add(lArm);
                    break;
                case BodyParts.RIGHTARM:
                    Line rArm = new Line();
                    rArm.Stroke = Brushes.Black;
                    rArm.X1 = 55;
                    rArm.Y1 = 110;
                    rArm.X2 = 85;
                    rArm.Y2 = 140;
                    canvas1.Children.Add(rArm);
                    break;
                case BodyParts.LEFTLEG:
                    Line lLeg = new Line();
                    lLeg.Stroke = Brushes.Black;
                    lLeg.X1 = 55;
                    lLeg.Y1 = 170;
                    lLeg.X2 = 25;
                    lLeg.Y2 = 200;
                    canvas1.Children.Add(lLeg);
                    break;
                case BodyParts.RIGHTLEG:
                    Line RLeg = new Line();
                    RLeg.Stroke = Brushes.Black;
                    RLeg.X1 = 55;
                    RLeg.Y1 = 170;
                    RLeg.X2 = 85;
                    RLeg.Y2 = 200;
                    canvas1.Children.Add(RLeg);
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
