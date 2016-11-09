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
        public MainWindow()
        {
            InitializeComponent();

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
    }
}
