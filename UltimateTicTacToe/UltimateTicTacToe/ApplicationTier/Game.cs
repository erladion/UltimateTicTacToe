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
        private MainBoard board = null;
        public Game()
        {

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
            this.board = new MainBoard(sba);
        }

        public void saveGame()
        {

        }

        public void loadGame()
        {

        }
        
        public MainBoard Board{
            get
            {
                return this.board;
            }
        }

        public Mark[,] createEmptyBoard()
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
    }
}
