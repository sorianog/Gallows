using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        private string wordToGuess = "";
        private static WordGenerator wordGen;
        private List<Label> chrLabels = new List<Label>();
        private int incorrect = 0;
        enum BodyParts
        {
            HEAD, BODY, LEFTARM, RIGHTARM, LEFTLEG, RIGHTLEG, LEFTEYE, RIGHTEYE, MOUTH
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            DrawHangPost();
            wordGen = new WordGenerator();
            wordToGuess = wordGen.GenerateWord();            
            MakeLabels();
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
        private void MakeLabels()
        {        
            char[] chars = wordToGuess.ToCharArray();
            double spcBetween = (wrdGrid.Width - 10) / chars.Length;
            for (int i = 0; i < chars.Length; i++)
            {                
                Label chrLabel = new Label();
                chrLabel.Margin = new Thickness((i * spcBetween) + 10, wrdGrid.Height / 2 - 20, 0, 0);
                chrLabel.FontSize = 20;
                chrLabel.Content = "_";
                chrLabels.Add(chrLabel);
                wrdGrid.Children.Add(chrLabel);                
            }
            wrdLenLbl.Content = "Word Length: " + wordToGuess.Length;
        }

        private void ltrBtn_Click(object sender, RoutedEventArgs e)
        {
            char ltr = ' ';
            if (ltrBox.Text.Length != 0)
            {
                ltr = ltrBox.Text.ToLower().ToCharArray()[0];
                if (!char.IsLetter(ltr))
                {
                    MessageBox.Show("Please submit letters only!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (wordToGuess.Contains(ltr.ToString()))
                {                    
                    char[] ltrsInWrd = wordToGuess.ToCharArray();
                    for (int i = 0; i < ltrsInWrd.Length; i++)
                    {
                        if (ltrsInWrd[i] == ltr)
                        {
                            chrLabels[i].Content = ltr.ToString();                            
                        }
                    }
                    foreach (Label lbl in chrLabels)
                    {
                        if (lbl.Content.Equals("_")) return;
                    }
                    MessageBox.Show("Congratulations! You have beaten the lyncher and revealed the hidden word!",
                                    "You Win", MessageBoxButton.OK, MessageBoxImage.Information);
                    DisableInput();
                }
                else
                {
                    MessageBox.Show("Sorry, the letter " + "\"" + ltr + "\"" + " is not in the word!", "Bad Letter", MessageBoxButton.OK, MessageBoxImage.Information);
                    mssdLtrsLbl.Content += ltr + "  ";
                    BadGuess();
                }
                ltrBox.Text = "";
            } else
            {
                MessageBox.Show("Please submit submit a letter!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }            
        }

        private void newWrdBtn_Click(object sender, RoutedEventArgs e)
        {
            wrdGrid.Children.RemoveRange(3, wordToGuess.Length);
            wordToGuess = wordGen.GenerateWord();           
            canvas1.Children.Clear();
            DrawHangPost();
            chrLabels = new List<Label>();
            MakeLabels();
            mssdLtrsLbl.Content = "Bad Letters:  ";
            incorrect = 0;
            ltrBtn.IsEnabled = true;
            ltrBox.IsEnabled = true;
            ltrBox.Text = "";
            wrdBtn.IsEnabled = true;
            wrdBox.IsEnabled = true;
            wrdBox.Text = "";
        }

        private void DisableInput()
        {
            ltrBtn.IsEnabled = false;
            ltrBox.Text = "";
            ltrBox.IsEnabled = false;
            wrdBtn.IsEnabled = false;
            wrdBox.IsEnabled = false;
        }

        private void wrdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (wrdBox.Text.ToLower() == wordToGuess)
            {
                MessageBox.Show("Congratulations! You have guessed the correct word which was " + wordToGuess + "!",
                                    "You Win", MessageBoxButton.OK, MessageBoxImage.Information);
                DisableInput();
            } else
            {
                MessageBox.Show("Sorry, " + wrdBox.Text + " is not the hidden word!", "Bad Word", MessageBoxButton.OK, MessageBoxImage.Information);
                BadGuess();
                wrdBox.Text = "";

            }
        }

        private void BadGuess()
        {
            DrawBodyPart((BodyParts)incorrect);
            incorrect++;
            if (incorrect == 9)
            {
                MessageBox.Show("Sorry, you have reached the maximum amount of guesses and have been hung! The word was: " + wordToGuess,
                                "You Lose", MessageBoxButton.OK, MessageBoxImage.Information);
                DisableInput();
            }
        }
    }
}
