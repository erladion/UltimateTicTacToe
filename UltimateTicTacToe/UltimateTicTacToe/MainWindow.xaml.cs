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
using System.Reflection;

namespace UltimateTicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationTier.Game g = null;
        public MainWindow()
        {
            InitializeComponent();

            this.g = new ApplicationTier.Game();            

            drawBoard();
        }        

        /// <summary>
        /// Parses the name of the rectangle and returns a point containing the position of the rectangle.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        private Point parseRect(Rectangle r)
        {            
            Point ret = new Point();            
            ret.X = Convert.ToDouble(r.Name[10].ToString());
            ret.Y = Convert.ToDouble(r.Name[11].ToString());            
            return ret;
        }

        /// <summary>
        /// Parses the name of the grid and returns a point containing the position of the grid.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        private Point parseGrid(Rectangle r)
        {
            Point ret = new Point();
            ret.X = Convert.ToDouble(r.Name[4].ToString());
            ret.Y = Convert.ToDouble(r.Name[5].ToString());
            return ret;
        }        

        private void colorRect(Rectangle r)
        {
            Color c = new Color();
            if(g.getActiveMark() == "cross")
            {
                c = Colors.Black;
            }
            else
            {
                c = Colors.Red;
            }
            r.Fill = new SolidColorBrush(c);
        }
        
        private void drawBoard()
        {
            for (int mbX = 0; mbX < g.getBoardSize(); mbX++)
            {
                for (int mbY = 0; mbY < g.getBoardSize(); mbY++)
                {
                    for (int sbX = 0; sbX < g.getBoardSize(); sbX++)
                    {
                        for (int sbY = 0; sbY < g.getBoardSize(); sbY++)
                        {
                            Rectangle r = (Rectangle)MainGrid.FindName("Grid" + mbX + mbY + "Rect" + sbX + sbY);
                            string shape = g.getShape(new Point(sbX, sbY), new Point(mbX, mbY));
                            if(new Point(mbX,mbY) == g.getActiveBoard())
                            {
                                fillRect(r, shape, Colors.PaleTurquoise);

                            }
                            else
                            {
                                fillRect(r, shape, Colors.LightGray);
                            }
                        }
                    }
                }
            }
            updateActiveBorder(g.getActiveBoard());
        }

        private void fillRect(Rectangle r, string shape, Color c)
        {
            
            r.Fill = new SolidColorBrush(c);
            Uri u = null;
            shape = shape.ToLower();
            if (shape == "circle")
            {
                u = new Uri("pack://application:,,,/Resources/circle.png");
            }
            else if (shape == "cross")
            {
                u = new Uri("pack://application:,,,/Resources/cross.png");

            }
            if (shape != "empty")
            {
                BitmapImage bmi = new BitmapImage(u);
                r.Fill = new ImageBrush(bmi);
            }
        }

        private void updateActiveBorder(Point ab)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Border b = (Border)MainGrid.FindName("Grid" + x + y + "Border");
                    b.Opacity = 0;
                }
            }         
            Border newActiveBorder = (Border)MainGrid.FindName("Grid" + ab.X + ab.Y + "Border");
            newActiveBorder.Opacity = 100;
        }

        private void newGameButtonClick(object sender, RoutedEventArgs e)
        {
            g.newGame();
            drawBoard();
        }

        private void loadButtonClick(object sender, RoutedEventArgs e)
        {
            g.loadGame();
            drawBoard();
        }
        private void saveButtonClick(object sender, RoutedEventArgs e)
        {
            g.saveGame();
        }

        private void click(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            Point clickedGrid = parseGrid(r);
            Point p = parseRect(r);
            if (g.clickHandle(p, clickedGrid))
            {
                drawBoard();
                g.checkIfWin(clickedGrid);
            }            
        }

        private void mouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            Point clickedGrid = parseGrid(r);
            if(clickedGrid == g.getActiveBoard() && g.getShape(parseRect(r),clickedGrid)=="empty")
            {
                fillRect(r, g.getActiveMark(), Colors.PaleTurquoise);
            }
        }

        private void mouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            Point clickedGrid = parseGrid(r);
            if (clickedGrid == g.getActiveBoard() && g.getShape(parseRect(r), clickedGrid) == "empty")
            {
                fillRect(r, "empty", Colors.PaleTurquoise);
            }
        }
    }
}
