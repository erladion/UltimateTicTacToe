using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UltimateTicTacToe.DataTier;

namespace UltimateTicTacToe.ApplicationTier
{
    class Game
    {
        private BoardLogic board = null;
        private DataLogic data = null;        
        public Game()
        {
            initGame();
        }

        public void initGame()
        {            
            SmallBoard[,] sba = new SmallBoard[3,3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    sba[x, y] = new SmallBoard(createEmptyBoard());                    
                }
            }
            Entity.EMainBoard board = new Entity.EMainBoard(sba, new Point(0,0), Mark.Cross);
            this.board = new BoardLogic(board);
            this.data = new DataLogic();
        }

        public bool clickHandle(Point pt, Point clickedBoard)
        {
            return board.clickHandle(pt,clickedBoard);
        }

        public bool checkIfWin(Point pt)
        {
            return board.checkIfWin(pt);
        }

        public void saveGame()
        {
            data.saveGame(board.Board);
        }

        public void loadGame()
        {
            board.Board = data.loadGame();
        }

        public void newGame()
        {
            board.resetBoard();

        }

        public int getBoardSize()
        {
            return board.BoardSize;
        }

        public string getActiveMark()
        {
            return board.ActiveMark.ToString();
        }

        private Mark[,] createEmptyBoard()
        {
            Mark[,] m = new Mark[3, 3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    m[x, y] = Mark.Empty;
                }
            }
            return m;
        }

        public string getShape(Point pt, Point board)
        {
            if (this.board.isCross(pt, board))
            {
                return "cross";

            }
            else if(this.board.isCircle(pt, board))
            {
                return "circle";
            }
            else
            {
                return "empty";
            }
        }

        public Point getActiveBoard()
        {
            return board.ActiveBoard;
        }
    }
}
