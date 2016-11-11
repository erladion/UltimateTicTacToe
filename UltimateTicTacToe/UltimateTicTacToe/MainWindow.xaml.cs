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

            this.g.MB.setActiveBoard(new Point(1, 1));

            
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
            if (clickedGrid == g.MB.ActiveBoard)
            {
                Point p = parseRect(r);
                g.MB.setActiveBoard(p);

                g.MB.placeMark(p);
                colorRect(r);
                g.MB.updateMark();
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
            if(g.MB.ActiveMark == ApplicationTier.Mark.Cross)
            {
                c = Colors.Black;
            }
            else
            {
                c = Colors.Red;
            }
            r.Fill = new SolidColorBrush(c);
        }


    }
}
