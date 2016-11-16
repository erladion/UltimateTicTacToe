using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateTicTacToe.ApplicationTier.Entity
{
    class EMainBoard
    {
        private const int boardSize = 3;
        private SmallBoard[,] boards = null;
        private Point activeBoard;
        private Mark activeMark = Mark.Cross;

        public int BoardSize
        {
            get
            {
                return boardSize;
            }            
        }

        public SmallBoard[,] Boards
        {
            get
            {
                return boards;
            }
            set
            {
                this.boards = value;
            }
        }

        public Point ActiveBoard
        {
            get
            {
                return activeBoard;
            }
            set
            {
                this.activeBoard = value;
            }
        }

        public Mark ActiveMark
        {
            get
            {
                return activeMark;
            }
            set
            {
                this.activeMark = value;
            }
        }
    }
}
