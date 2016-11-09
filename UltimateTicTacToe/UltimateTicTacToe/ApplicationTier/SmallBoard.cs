using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateTicTacToe.ApplicationTier
{
    enum Mark
    {        
        Empty,
        Cross,
        Circle
    };

    class SmallBoard : SmallBoardInterface
    {
        private int boardSize = 3;
        private Mark[,] board;

        public SmallBoard(Mark[,] board)
        {
            try
            {
                validateBoard(board);
            }
            catch (BoardSizeException)
            {

            }            
        }

        private void validateBoard(Mark[,] board)
        {
            if (board.Rank == 2 && board.GetUpperBound(0) == boardSize-1 && board.GetUpperBound(1) == boardSize - 1)
            {
                this.board = board;
            }
            else
            {
                throw new BoardSizeException("Board size is not valid, should be 2D-array with size 3");                           
            }
        }
        
        public Mark getMark(Point pt)
        {
            try
            {
                if (pt.X <= boardSize - 1 && pt.Y <= boardSize - 1)
                {
                    return board[(int)pt.X, (int)pt.Y];
                }
                else
                {
                    throw new BoardSizeException("Index out of bounds");
                }             
            }
            catch (BoardSizeException)
            {
                return Mark.Empty;
            }            
        }

        public void setMark(Point pt, Mark mark)
        {
            try
            {
                if (pt.X <= boardSize - 1 && pt.Y <= boardSize - 1)
                {
                    board[(int)pt.X, (int)pt.Y] = mark;
                }
                else
                {
                    throw new BoardSizeException("Index out of bounds");
                }
            }
            catch (BoardSizeException)
            {

            }
        }
        public Mark[,] Board
        {
            get
            {
                return board;
            }
        }
    }
}
