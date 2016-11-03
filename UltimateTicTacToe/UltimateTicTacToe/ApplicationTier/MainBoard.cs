using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateTicTacToe.ApplicationTier
{
    class MainBoard
    {
        SmallBoard[,] boards = null;
        Point activeBoard;

        public MainBoard(SmallBoard[,] boards, Point activeBoard)
        {
            this.boards = boards;
            this.activeBoard = activeBoard;
        }
    }
}
