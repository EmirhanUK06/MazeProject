using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MazeGame
{
    public class DataRead
    {
        StreamReader sr = new StreamReader(@"C:\Users\emirh\Desktop\midterm2\Maze.txt");
        public string[,] Maze = new string[30, 30];
        public string[,] Maze2 = new string[30, 30];
        public string[,] Maze3 = new string[30, 30];
        public string test;
        public void read()
        {
            int i = 0;
            string matrix = "";
            //Burada tanımlamalarımı yaptım. "matrix" tanımı not defterinden çektiğim veriyi temizlemek ve sıralamak için kullanacaktır.
            while (!sr.EndOfStream)
            {
                matrix += sr.ReadLine() + "";
            }
            //Burada sr.ReadLine() ile matrixe not defterindeki verileri atadım.
            sr.Close();

            test = matrix.Replace(",", "");
            test = test.Replace("{", "");
            test = test.Replace("}", "");
            test = test.Replace(" ", "");

            //Matrixi ','  '{ }' ve ' ' karakterinden arındırdım.

            for (int j = 0; j < 30; j++)
            {
                for (int k = 0; k < 30; k++)
                {
                    Maze[j, k] = test.Substring(i, 1).ToString();
                    Maze2[j, k] = test.Substring(i, 1).ToString(); 
                    Maze3[j, k] = test.Substring(i, 1).ToString(); // Orijinal hali

                    //Console.Write(Maze[j, k]);
                    i++;
                    
                }
            } 
            //Console.WriteLine(Maze[0,0]);
            //For döngüsü ile matrixi Maze[a,b] ile 30x30 atama yaptım.
            //Console.ReadKey();
        }
    }

}
