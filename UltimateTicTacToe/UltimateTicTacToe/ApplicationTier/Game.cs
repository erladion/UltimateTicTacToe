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
        private MainBoard mb = null;
        public Game()
        {

        }

        public void initGame()
        {
            Mark[,] m = new Mark[3,3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    m[x, y] = Mark.Empty;
                }
            }
            SmallBoard sb = new SmallBoard(m);

            SmallBoard[,] sba = new SmallBoard[3,3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    sba[x,y] = sb;
                }
            }
            this.mb = new MainBoard(sba);
        }

        public MainBoard MB{
            get
            {
                return this.mb;
            }
        }
    }
}
