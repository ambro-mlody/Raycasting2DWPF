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
using Raycasting2DLibrary;
using System.Numerics;

namespace Raycasting2DUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Particle particle;
        List<Boundary> walls;
        int clicks;

        public MainWindow()
        {
            
            InitializeComponent();


            walls = new List<Boundary>();
            clicks = 0;
            //Line line = new Line();
            //line.X1 = 10;
            //line.Y1 = 10;
            //line.X2 = 200;
            //line.Y2 = 100;
            //line.Stroke = Brushes.White;
            //canvas.Children.Add(line); 



        }

        void draw()
        {
            List<Vector2> points;
            canvas.Children.Clear();

            points = particle.look(ref walls);
            foreach (var wall in walls)
            {
                Line line = new Line();
                line.X1 = wall.a.X;
                line.Y1 = wall.a.Y;
                line.X2 = wall.b.X;
                line.Y2 = wall.b.Y;
                line.Stroke = Brushes.White;
                line.StrokeThickness = 2;
                canvas.Children.Add(line);
            }

            foreach (var point in points)
            {
                //float d = Vector2.DistanceSquared(particle.position, point);

                Line line = new Line();
                line.X1 = particle.position.X;
                line.Y1 = particle.position.Y;
                line.X2 = point.X;
                line.Y2 = point.Y;
                line.Stroke = Brushes.White;
                line.StrokeThickness = 1;
                line.Opacity = 0.5;

                canvas.Children.Add(line);
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            var rand = new Random();

            canvas.Children.Clear();
            walls.Clear();

            int W = (int)canvas.ActualWidth;
            int H = (int)canvas.ActualHeight;

            for (int i = 0; i < 5; i++)
            {
                int x1 = rand.Next(W);
                int y1 = rand.Next(H);
                int x2 = rand.Next(W);
                int y2 = rand.Next(H);

                walls.Add(new Boundary(x1, y1, x2, y2));

            }

            walls.Add(new Boundary(0, 0, 0, H));
            walls.Add(new Boundary(0, 0, W, 0));
            walls.Add(new Boundary(0, H, W, H));
            walls.Add(new Boundary(W - 1, 0, W - 1, H));

            particle = new Particle(W / 2, H / 2);

            draw();

            clicks++;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(clicks > 0)
            {
                Vector2 mousePos = new Vector2();
                Point p = Mouse.GetPosition(canvas);
                mousePos.X = (float)p.X;
                mousePos.Y = (float)p.Y;
                particle.update(mousePos);
                draw();
            }
            
        }
    }
}
