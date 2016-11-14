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
            this.g.initGame();

            this.g.Board.setActiveBoard(new Point(1, 1));

            drawBoard();       
            
            /*
            Border b = (Border)Grid11.FindName("Grid11Border");
            b.BorderBrush = new SolidColorBrush(Colors.Red);
            */  
                      
            /*
            *https://msdn.microsoft.com/en-us/library/system.windows.frameworkelement.findname.aspx
            *http://stackoverflow.com/questions/223952/create-an-instance-of-a-class-from-a-string
            *http://stackoverflow.com/questions/23060609/access-objects-in-usercontrol-from-mainwindow-in-wpf
            */

            /*Object obj = Grid11.FindName("Grid11Rect11");
            System.Windows.Shapes.Rectangle r = (Rectangle)obj;
            */

            /*
            Grid g = (Grid)MainGrid.FindName("Grid11");
            Rectangle r = (Rectangle)g.FindName("Grid" + x.ToString() + y.ToString() + "Rect" + x.ToString() + y.ToString());
            r.Fill = new SolidColorBrush(Colors.Black);
            */
        }   
        
        private void click(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            Point clickedGrid = parseGrid(r);
            if (clickedGrid == g.Board.ActiveBoard)
            {
                Point p = parseRect(r);                
                if (g.Board.clickHandle(p))
                {
                    updateActiveBorder(p, clickedGrid);
                    drawBoard();
                    g.Board.checkIfWin(p);
                }                            
            }            
        }

        private Point parseRect(Rectangle r)
        {            
            Point ret = new Point();            
            ret.X = Convert.ToDouble(r.Name[10].ToString());
            ret.Y = Convert.ToDouble(r.Name[11].ToString());            
            return ret;
        }

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
            if(g.Board.isTurnCross())
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
            for (int mbX = 1; mbX <= g.Board.BoardSize; mbX++)
            {
                for (int mbY = 1; mbY <= g.Board.BoardSize; mbY++)
                {
                    for (int sbX = 1; sbX <= g.Board.BoardSize; sbX++)
                    {
                        for (int sbY = 1; sbY <= g.Board.BoardSize; sbY++)
                        {
                            Rectangle r = (Rectangle)MainGrid.FindName("Grid" + mbX + mbY + "Rect" + sbX + sbY);
                            Color c = Colors.LightGray;
                            if(g.Board.isCircle(new Point(sbX, sbY), new Point(mbX, mbY))){
                                c = Colors.Red;
                            }
                            else if(g.Board.isCross(new Point(sbX, sbY), new Point(mbX, mbY))){
                                c = Colors.Black;
                            }
                            r.Fill = new SolidColorBrush(c);
                        }
                    }
                }
            }
        }

        private void updateActiveBorder(Point newAB, Point oldAB)
        {            
            Border oldBorder = (Border)MainGrid.FindName("Grid" + oldAB.X + oldAB.Y + "Border");
            Border newBorder = (Border)MainGrid.FindName("Grid" + newAB.X + newAB.Y + "Border");                     
            oldBorder.Opacity = 0;
            newBorder.Opacity = 100;
        }
    }
}
