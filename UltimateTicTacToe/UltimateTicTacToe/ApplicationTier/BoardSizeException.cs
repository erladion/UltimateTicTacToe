using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToe.ApplicationTier
{
    class BoardSizeException : Exception
    {
        public BoardSizeException()
        {

        }

        public BoardSizeException(string message) : base(message)
        {

        } 
    }
}
