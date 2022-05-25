using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Bombs
    {
        public int[] bombline = new int[3];
        public int[] bombcolumn = new int[3];
        public void bomb()
        {
            
            Random rnd = new Random();
            DataRead dataRead = new DataRead();
            Position position = new Position();
            dataRead.read();
            do
            {
                    bombline[0] = rnd.Next(0, 30);
                    bombline[1] = rnd.Next(0, 30);
                    bombline[2] = rnd.Next(0, 30);
                    bombcolumn[0] = rnd.Next(0, 30);
                    bombcolumn[1] = rnd.Next(0, 30);
                    bombcolumn[2] = rnd.Next(0, 30);
            }
            while (dataRead.Maze[bombline[0], bombcolumn[0]] == "1" && dataRead.Maze[bombline[1],bombcolumn[1]] == "1" && dataRead.Maze[bombline[2],bombcolumn[2]] == "1");

            for (int k = 0; k < 3; k++)
            {
               // Console.WriteLine(bombline[k] + "," + bombcolumn[k]);
            }
        }
    }
}
