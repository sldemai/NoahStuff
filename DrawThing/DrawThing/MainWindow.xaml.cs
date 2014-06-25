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

namespace DrawThing
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
        //Figured out with help from the power of the internet ~ Noah
        void PushMe_Button(object sender, RoutedEventArgs e)
        {
            //Copied and pasted ~ Noah
            DrawingCanvas.Children.Clear();
            
            //Half copied, half figured out on own ~ Noah
            double bigCenter1 = DrawingCanvas.Height / 2;
            double bigCenter2 = DrawingCanvas.Width / 2;
            double biggerRadius = 50;

            //Actually figured it out on my own, after 50 minutes ~ Noah
            Ellipse bigCircle = new Ellipse();
            
            //Pretty much copy and pasted from your work ~ Noah
            bigCircle.Height = biggerRadius * 2;
            bigCircle.Width = biggerRadius * 2;

            //Pretty much copy and pasted from your work ~ Noah
            bigCircle.StrokeThickness = 5;
            bigCircle.Stroke = Brushes.White;

            //Couldn't get it to go to the center so I had to guess and check ~ Noah
            double center1 = bigCenter1;
            double center2 = bigCenter2;
            Canvas.SetLeft(bigCircle, center1 + 50);
            Canvas.SetTop(bigCircle, center2 - 160);

            //Draws the circle ~ Noah (Also, I couldn't figure out how to fill the circle with color.)
            DrawingCanvas.Children.Add(bigCircle);


            //Same things: adding more circles ~ Noah
            double smallerRadius = 30;

            Ellipse smallCircle = new Ellipse();

            smallCircle.Height = smallerRadius * 2;
            smallCircle.Width = smallerRadius * 2;

            smallCircle.StrokeThickness = 5;
            smallCircle.Stroke = Brushes.YellowGreen;

            double center3 = bigCenter1;
            double center4 = bigCenter2;
            Canvas.SetLeft(smallCircle, center3 + 70);
            Canvas.SetTop(smallCircle, center4 - 140);

            DrawingCanvas.Children.Add(smallCircle);


            //Adding a third circle
            double biggestRadius = 70;

            Ellipse biggestCircle = new Ellipse();

            biggestCircle.Height = biggestRadius * 2;
            biggestCircle.Width = biggestRadius * 2;

            biggestCircle.StrokeThickness = 5;
            biggestCircle.Stroke = Brushes.Blue;

            double center5 = bigCenter1;
            double center6 = bigCenter2;
            Canvas.SetLeft(biggestCircle, center5 + 30);
            Canvas.SetTop(biggestCircle, center6 - 180);

            DrawingCanvas.Children.Add(biggestCircle);


            //Adding a fourth circle
            double biggerestRadius = 90;

            Ellipse biggerestCircle = new Ellipse();

            biggerestCircle.Height = biggerestRadius * 2;
            biggerestCircle.Width = biggerestRadius * 2;

            biggerestCircle.StrokeThickness = 5;
            biggerestCircle.Stroke = Brushes.OrangeRed;

            double center7 = bigCenter1;
            double center8 = bigCenter2;
            Canvas.SetLeft(biggerestCircle, center7 + 10);
            Canvas.SetTop(biggerestCircle, center8 - 200);

            DrawingCanvas.Children.Add(biggerestCircle);

            //Add a large square
            //declare square radius
            double rectRadius = 110;
            
            //declare the new square
            Rectangle largeRect = new Rectangle();

            //declare height and width of rectangle
            largeRect.Height = rectRadius * 2;
            largeRect.Width = rectRadius * 2;

            //declaring outline details
            largeRect.StrokeThickness = 5;
            largeRect.Stroke = Brushes.HotPink;

            //declare square location
            double middle1 = bigCenter1;
            double middle2 = bigCenter2;
            Canvas.SetLeft(largeRect, middle1 - 10);
            Canvas.SetTop(largeRect, middle2 - 220);

            //Draw the square
            DrawingCanvas.Children.Add(largeRect);

        }
        
        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            // Remove anything that is currently being drawn
            DrawingCanvas.Children.Clear();

            // Figure out the center point for the circles
            //  and the radius of the big circle on which the little circles will sit
            double bigCenterX = DrawingCanvas.Width / 2;
            double bigCenterY = DrawingCanvas.Height / 2;
            double bigRadius = 80;

            // How big should each circle be?
            double diameter = 60;

            // Figure out how many circles to draw
            int circleCount = Convert.ToInt32(CircleCount.Text);

            // Draw a number of circles
            for (int n = 0; n < circleCount; ++n)
            {
                double percentDone = (double)n / circleCount;

                Ellipse circle = new Ellipse();

                // Set the width/height of the circle
                circle.Height = diameter;
                circle.Width = diameter;

                // Set the position of the circle
                double centerX = bigCenterX + (bigRadius * Math.Sin(percentDone * Math.PI * 2)) - (diameter / 2);
                double centerY = bigCenterY - (bigRadius * Math.Cos(percentDone * Math.PI * 2)) - (diameter / 2);
                Canvas.SetLeft(circle, centerX);
                Canvas.SetTop(circle, centerY);

                // Set the color of the circle
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Color.FromArgb(255, (byte)(255 * (1 - percentDone)), (byte)(255 * percentDone), 0);
                circle.Fill = brush;
                circle.StrokeThickness = 2;
                circle.Stroke = Brushes.Yellow;

                // Draw the circle
                DrawingCanvas.Children.Add(circle);
            }            
        }
    }
}
