using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateTicTacToe.ApplicationTier
{
    interface SmallBoardInterface
    {
        Mark getMark(Point pt);

        void setMark(Point pt, Mark mark);
    }
}
