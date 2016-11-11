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
        private const int boardSize = 3;
        private SmallBoard[,] boards = null;
        private Point activeBoard;
        private Mark activeMark = Mark.Cross;

        public MainBoard(SmallBoard[,] boards, Point activeBoard)
        {
            try
            {
                validateBoard(boards);
                validateActiveBoard(activeBoard);
            }
            catch (BoardSizeException)
            {
                throw new BoardSizeException();
            }            
            this.activeBoard = activeBoard;
        }

        public MainBoard(SmallBoard[,] boards)
        {
            try
            {
                validateBoard(boards);
                validateActiveBoard(activeBoard);
            }
            catch (BoardSizeException)
            {
                throw new BoardSizeException();
            }            
        }

        private void validateBoard(SmallBoard[,] boards)
        {
            if (boards.Rank == 2 && boards.GetUpperBound(0) == boardSize - 1 && boards.GetUpperBound(1) == boardSize - 1)
            {
                this.boards = boards;
            }
            else
            {
                throw new BoardSizeException("Board size is not valid, should be 2D-array with size 3");
            }
        }

        private void validateActiveBoard(Point pt)
        {
            if (pt.X <= boardSize && pt.Y <= boardSize)
            {
                this.activeBoard = pt;
            }
            else
            {
                throw new BoardSizeException("Activeboard does not exist, check activeBoard size");
            }
        }

        public void setActiveBoard(Point newActiveBoard)
        {
            validateActiveBoard(newActiveBoard);
        }

        public void placeMark(Point pt)
        {
            if(pt.X <= boardSize && pt.Y <= boardSize)
            {
                boards[(int)activeBoard.X-1, (int)activeBoard.Y-1].setMark(pt, activeMark); 
            }
            else
            {
                throw new BoardSizeException();
            }
        }

        public Point ActiveBoard
        {
            get
            {
                return activeBoard;
            }
        }

        public void updateMark()
        {
            if(activeMark == Mark.Circle)
            {
                activeMark = Mark.Cross;
            }
            else
            {
                activeMark = Mark.Circle;
            }
        }

        public Mark ActiveMark
        {
            get
            {
                return this.activeMark;
            }
        }
    }
}
