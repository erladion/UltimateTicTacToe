using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateTicTacToe.ApplicationTier
{
    class Game
    {
        private BoardLogic board = null;
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
            Entity.EMainBoard board = new Entity.EMainBoard(sba, new Point(1,1), Mark.Cross);
            this.board = new BoardLogic(board);
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

        }

        public void loadGame()
        {

        }

        public void newGame()
        {
            board.resetBoard();
        }

        public BoardLogic Board{
            get
            {
                return this.board;
            }
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
    }
}
