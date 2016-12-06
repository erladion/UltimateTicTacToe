using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateTicTacToe.ApplicationTier.Entity;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows;
using System.Reflection;
using UltimateTicTacToe.ApplicationTier;

namespace UltimateTicTacToe.DataTier
{
    /*
    *   0 1 2
    *   3 4 5
    *   6 7 8
    */

    /*
    * <BoardEntity>
    *   <MainBoard> 
    *       <Board>
    *       <Mark> empty </Mark>        
    *           *9
    *       </Board>
    *   
    *       *9
    *
    *
    *   </MainBoard>
    * 
    *   <BoardSize> 3 </BoardSize>
    *   <ActiveMark> cross </ActiveMark> 
    *   <ActiveBoard> 1,1 </ActiveBoard>
    * </BoardEntity>
    */

    class DataLogic
    {
        public bool saveGame(EMainBoard board)
        {
            boardToXML(board);
            return true;
        }

        public EMainBoard loadGame()
        {            
            return boardFromXML(); ;
        }

        private string getMark(int i, int j, EMainBoard b)
        {
            return b.Boards[i%3, (int)i/3].getMark(new Point(j% 3, (int)j / 3)).ToString();
        }        

        private void boardToXML(EMainBoard board)
        {
            XElement MainBoardContent = new XElement("MainBoard"

            );            

            for (int i = 0; i < 9; i++)
            {
                XElement Board = new XElement("Board");
                for (int j = 0; j < 9; j++)
                {
                    Board.Add(new XElement("Mark", getMark(i, j, board)));
                }
                MainBoardContent.Add(Board);
            }
            XDocument doc = new XDocument(
                new XElement("BoardEntity", MainBoardContent,
                    new XElement("BoardSize", board.BoardSize.ToString()),
                    new XElement("ActiveMark", board.ActiveMark.ToString()),
                    new XElement("ActiveBoardX", board.ActiveBoard.X.ToString()),
                    new XElement("ActiveBoardY", board.ActiveBoard.Y.ToString())
                )
            );

            doc.Save("saveFile.xml");
            Console.WriteLine(File.ReadAllText("saveFile.xml"));
        }

        private EMainBoard boardFromXML()
        {
            //Uri path = new Uri("pack://application:,,,/saveFile.xml");
            
            XDocument doc = XDocument.Load("saveFile.xml");

            var children = from r in doc.Descendants("BoardEntity")
                           select new
                           {
                               MainBoard = r.Element("MainBoard"),
                               BoardSize = r.Element("BoardSize").Value,
                               ActiveMark = r.Element("ActiveMark").Value,
                               ActiveBoardX = r.Element("ActiveBoardX").Value,
                               ActiveBoardY = r.Element("ActiveBoardY").Value
                           };


            SmallBoard[,] sb = parseMainBoard(children.ElementAt(0).MainBoard);
            Mark m = (children.ElementAt(0).ActiveMark == "Circle") ? Mark.Circle : Mark.Cross;

            return new EMainBoard(sb, new Point(Convert.ToDouble(children.ElementAt(0).ActiveBoardX), Convert.ToDouble(children.ElementAt(0).ActiveBoardY)), m);
        }

        private SmallBoard[,] parseMainBoard(XElement board)
        {
            var boards = from b in board.Descendants("Board")
                         select new
                         {
                             Mark0 = b.Element("Mark").Value,
                             Mark1 = b.Element("Mark").Value,
                             Mark2 = b.Element("Mark").Value,
                             Mark3 = b.Element("Mark").Value,
                             Mark4 = b.Element("Mark").Value,
                             Mark5 = b.Element("Mark").Value,
                             Mark6 = b.Element("Mark").Value,
                             Mark7 = b.Element("Mark").Value,
                             Mark8 = b.Element("Mark").Value,
                         };
            
            SmallBoard[,] sb = new SmallBoard[3,3];

            int count = 0;
            foreach (var item in boards)
            {
                if(count == 9)
                {
                    count = 0;
                }
                Type t = item.GetType();
                PropertyInfo[] pi = t.GetProperties();
                Mark[,] m = new Mark[3, 3];
                for (int i = 0; i < 9; i++)
                {                    
                    object d = pi[i].GetValue(item);

                    m[i % 3, i / 3] = (d.ToString() == "Circle") ? Mark.Circle : (d.ToString() == "Cross") ? Mark.Cross : Mark.Empty; 
                }                
                sb[count % 3, count / 3] = new SmallBoard(m);

                count++;
            }

            return sb;
        }
    }
}
