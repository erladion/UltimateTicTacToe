using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateTicTacToe.ApplicationTier
{
    class BoardLogic
    {
        /*
        private const int boardSize = 3;
        private SmallBoard[,] boards = null;
        private Point activeBoard;
        private Mark activeMark = Mark.Cross;
        private bool firstTurn = true;
        */
        private Entity.EMainBoard board;

        public BoardLogic(Entity.EMainBoard board)
        {
            try
            {
                if (validateBoardEntity(board))
                {
                    this.board = board;
                }
                else
                {
                    throw new BoardSizeException();
                }                
            }
            catch (BoardSizeException)
            {
                throw new BoardSizeException();
            }            
        }        

        private bool validateBoardEntity(Entity.EMainBoard board)
        {
            if (board.Boards.Rank == 2 && board.Boards.GetUpperBound(0) == board.BoardSize - 1 && board.Boards.GetUpperBound(1) == board.BoardSize - 1 && validPoint(board.ActiveBoard,board.BoardSize))
            {
                
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool validateBoard(SmallBoard[,] boards)
        {
            if (boards.Rank == 2 && boards.GetUpperBound(0) == board.BoardSize - 1 && boards.GetUpperBound(1) == board.BoardSize - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validateActiveBoard(Point pt)
        {
            if (validPoint(pt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }        

        public bool clickHandle(Point pt, Point clickedBoard)
        {
            if (placeMark(pt, board.ActiveBoard, clickedBoard)) {

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
            SmallBoard b = board.Boards[(int)pt.X, (int)pt.Y];            
            List<List<Mark>> allCombinations = generateLists(b);
           
            for (int i = 0; i < allCombinations.Count; i++)
            {
                if (testIfWin(allCombinations[i]).Count == 3)
                {
                    MessageBox.Show("WIN WIN WIN");
                }
            }
            return true;
        }

        private List<Mark> testIfWin(List<Mark> t)
        {
            if (t[0] == t[1] && t[0] == t[2] && t[0] != Mark.Empty)
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
            List<List<Mark>> ret = new List<List<Mark>>()
            {
                new List<Mark>() { board.getMark(new Point(0, 0)), board.getMark(new Point(0, 1)), board.getMark(new Point(0, 2))},
                new List<Mark>() { board.getMark(new Point(0, 0)), board.getMark(new Point(1, 0)), board.getMark(new Point(2, 0))},
                new List<Mark>() { board.getMark(new Point(0, 0)), board.getMark(new Point(1, 1)), board.getMark(new Point(2, 2))},
                new List<Mark>() { board.getMark(new Point(0, 1)), board.getMark(new Point(1, 1)), board.getMark(new Point(2, 1))},
                new List<Mark>() { board.getMark(new Point(0, 2)), board.getMark(new Point(1, 2)), board.getMark(new Point(2, 2))},
                new List<Mark>() { board.getMark(new Point(1, 0)), board.getMark(new Point(1, 1)), board.getMark(new Point(1, 2))},
                new List<Mark>() { board.getMark(new Point(2, 0)), board.getMark(new Point(2, 1)), board.getMark(new Point(2, 2))},
                new List<Mark>() { board.getMark(new Point(0, 2)), board.getMark(new Point(1, 1)), board.getMark(new Point(2, 0))}
            };           
            return ret;
        }

        public bool isTurnCross()
        {
            return (board.ActiveMark == Mark.Cross);
        }

        public void setActiveBoard(Point newActiveBoard)
        {
            if (validateActiveBoard(newActiveBoard))
            {
                board.ActiveBoard = newActiveBoard;
            }
        }

        public bool placeMark(Point pt, Point board, Point clickedBoard)
        {
            if(validPoint(pt) && validPoint(board) && validPosition(pt, board) && board==clickedBoard)
            {
                this.board.Boards[(int)board.X, (int)board.Y].setMark(pt, this.board.ActiveMark);
                return true; 
            }
            else
            {
                return false;
            }            
        }

        private bool validPosition(Point pt, Point board)
        {
            //MessageBox.Show("Point 1: " + pt.X.ToString() + "," + pt.Y.ToString() + "Point 2: " + board.X.ToString() + "," + board.Y.ToString() + "? " + (boards[(int)board.X - 1, (int)board.Y - 1].getMark(pt)).ToString());
            return (Mark.Empty == this.board.Boards[(int)board.X, (int)board.Y].getMark(pt));
        }

        public Point ActiveBoard
        {
            get
            {
                return board.ActiveBoard;
            }
        }

        public void updateMark()
        {
            if(board.ActiveMark == Mark.Circle)
            {
                board.ActiveMark = Mark.Cross;
            }
            else
            {
                board.ActiveMark = Mark.Circle;
            }
        }

        private bool validPoint(Point pt)
        {
            return (pt.X <= board.BoardSize && pt.Y <= board.BoardSize);
        }

        private bool validPoint(Point pt, int boardSize)
        {
            return (pt.X <= boardSize && pt.Y <= boardSize);
        }

        public Mark ActiveMark
        {
            get
            {
                return board.ActiveMark;
            }
        }        

        public int BoardSize
        {
            get
            {
                return board.BoardSize;
            }
        }

        public bool isCircle(Point pt, Point board)
        {
            return (this.board.Boards[(int)board.X, (int)board.Y].getMark(pt) == Mark.Circle);
        }

        public bool isCross(Point pt, Point board)
        {
            return (this.board.Boards[(int)board.X, (int)board.Y].getMark(pt) == Mark.Cross);
        }
        public bool isEmpty(Point pt, Point board)
        {
            return (this.board.Boards[(int)board.X, (int)board.Y].getMark(pt) == Mark.Empty);
        }

        public void resetBoard()
        {
            for (int x = 0; x < board.BoardSize; x++)
            {
                for (int y = 0; y < board.BoardSize; y++)
                {
                    this.board.Boards[x, y].reset();
                }
            }
            this.board.ActiveMark = Mark.Cross;
            setActiveBoard(new Point(0, 0));

        }

        public Entity.EMainBoard Board
        {
            get
            {
                return board;
            }
            set
            {
                this.board = value;
            }
        }
    }
}

