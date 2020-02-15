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

namespace Raycasting2DUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Boundary> walls;

        public MainWindow()
        {
            InitializeComponent();

            List<Boundary> walls = new List<Boundary>();
            if (canvas.IsInitialized)
                setup();

        }

        void setup()
        {
            var rand = new Random();
            int W = (int)canvas.ActualWidth;
            int H = (int)canvas.ActualHeight;

            for (int i = 0; i < 5; i++)
            {
                int x1 = rand.Next(W);
                int y1 = rand.Next(H);
                int x2 = rand.Next(W);
                int y2 = rand.Next(H);

                walls.Add( new Boundary(x1, y1, x2, y2));

            }

            walls.Add(new Boundary(0, 0, 0, H));
            walls.Add(new Boundary(0, 0, W, 0));
            walls.Add(new Boundary(0, H, W, H));
            walls.Add(new Boundary(W - 1, 0, W - 1, H));
        }
    }
}
