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
                if (validPoint(pt))
                {
                    return board[(int)pt.X-1, (int)pt.Y-1];
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
                if (validPoint(pt))
                {
                    if(validPlacement(pt, mark)) { 
                        board[(int)pt.X-1, (int)pt.Y-1] = mark;
                    }
                    else
                    {
                        // Need exception here
                    }
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

        private bool validPoint(Point pt)
        {
            return (pt.X <= boardSize && pt.Y <= boardSize) ? true : false;
        }        

        private bool validPlacement(Point pt, Mark mark)
        {
            try
            {
                if (validPoint(pt))
                {
                    return (board[(int)pt.X-1, (int)pt.Y-1] == Mark.Empty) ? true : false;                    
                }
                else
                {
                    // This should be a new exception and not just Exception
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw;
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
