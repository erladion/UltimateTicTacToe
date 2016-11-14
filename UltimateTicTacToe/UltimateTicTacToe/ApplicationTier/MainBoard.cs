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
            if (validPoint(pt))
            {
                this.activeBoard = pt;
            }
            else
            {
                throw new BoardSizeException("Activeboard does not exist, check activeBoard size");
            }
        }

        public bool clickHandle(Point pt)
        {
            if (placeMark(pt, activeBoard)) { 
                setActiveBoard(pt);            
                updateMark();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkIfWin(Point pt)
        {
            SmallBoard b = boards[(int)pt.X, (int)pt.Y];            
            List<List<Mark>> allCombinations = generateLists(b);

            //List<Mark> winList = new List<Mark>();
            for (int i = 0; i < allCombinations.Count; i++)
            {
                if (test(allCombinations[i]).Count == 3)
                {
                    MessageBox.Show("WIN WIN WIN");
                }
            }            

            return true;
        }

        private List<Mark> test(List<Mark> t)
        {
            if (t[0] == t[1] && t[0] == t[2])
            {
                return t;
            }
            else
            {
                return new List<Mark>();
            }
        }

        private List<List<Mark>> generateLists(SmallBoard board)
        {
            List<List<Mark>> ret = new List<List<Mark>>();
            ret[0] = new List<Mark>(){board.getMark(new Point(1, 1)), board.getMark(new Point(1, 2)), board.getMark(new Point(1,3))};
            ret[1] = new List<Mark>() { board.getMark(new Point(1, 1)), board.getMark(new Point(2, 1)), board.getMark(new Point(3, 1)) };
            ret[2] = new List<Mark>() { board.getMark(new Point(1, 1)), board.getMark(new Point(2, 2)), board.getMark(new Point(3, 3)) };
            ret[3] = new List<Mark>() { board.getMark(new Point(1, 2)), board.getMark(new Point(2, 2)), board.getMark(new Point(3, 2)) };
            ret[4] = new List<Mark>() { board.getMark(new Point(1, 3)), board.getMark(new Point(2, 3)), board.getMark(new Point(3, 3)) };
            ret[5] = new List<Mark>() { board.getMark(new Point(2, 1)), board.getMark(new Point(2, 2)), board.getMark(new Point(2, 3)) };
            ret[6] = new List<Mark>() { board.getMark(new Point(3, 1)), board.getMark(new Point(3, 2)), board.getMark(new Point(3, 3)) };
            ret[7] = new List<Mark>() { board.getMark(new Point(1, 3)), board.getMark(new Point(2, 2)), board.getMark(new Point(3, 1)) };
            return ret;
        }

        public bool isTurnCross()
        {
            return (activeMark == Mark.Cross);
        }

        public void setActiveBoard(Point newActiveBoard)
        {
            validateActiveBoard(newActiveBoard);
        }

        public bool placeMark(Point pt, Point board)
        {
            if(validPoint(pt) && validPoint(board) && validPosition(pt, board))
            {
                boards[(int)board.X-1, (int)board.Y-1].setMark(pt, activeMark);
                return true; 
            }
            else
            {
                return false;
            }            
        }

        private bool validPosition(Point pt, Point board)
        {
            MessageBox.Show("Point 1: " + pt.X.ToString() + "," + pt.Y.ToString() + "Point 2: " + board.X.ToString() + "," + board.Y.ToString() + "? " + (boards[(int)board.X - 1, (int)board.Y - 1].getMark(pt)).ToString());
            return (Mark.Empty == boards[(int)board.X - 1, (int)board.Y - 1].getMark(pt));
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

        private bool validPoint(Point pt)
        {
            return (pt.X <= boardSize && pt.Y <= boardSize) ? true : false;
        }

        public Mark ActiveMark
        {
            get
            {
                return this.activeMark;
            }
        }        

        public int BoardSize
        {
            get
            {
                return boardSize;
            }
        }

        public bool isCircle(Point pt, Point board)
        {
            return (boards[(int)board.X-1, (int)board.Y-1].getMark(pt) == Mark.Circle);
        }

        public bool isCross(Point pt, Point board)
        {
            return (boards[(int)board.X-1, (int)board.Y-1].getMark(pt) == Mark.Cross);
        }
        public bool isEmpty(Point pt, Point board)
        {
            return (boards[(int)board.X-1, (int)board.Y-1].getMark(pt) == Mark.Empty);
        }
    }
}

