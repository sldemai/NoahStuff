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
            double diameter = 40;

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
                brush.Color = Color.FromArgb(255, 0, (byte)(255 * (1 - percentDone)), (byte)(255 * percentDone));
                circle.Fill = brush;
                circle.StrokeThickness = 1;
                circle.Stroke = Brushes.Black;

                // Draw the circle
                DrawingCanvas.Children.Add(circle);
            }
        }
    }
}
