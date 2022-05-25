using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Creator
    {
        public void creator()
        {
            Random rnd = new Random();
            int[,] library = new int[30, 30];
            int x = 0, y = 0;

            for (int m = 0; m<3;m++)
            {
                int temp = m;
                m = rnd.Next(0, 30);
                library[m, 0] = 1;
                m = temp;
            }
            for (x = 0; x < 30; x++)
            {
                Console.WriteLine("\n");
                for (y = 0; y < 30; y++)
                {
                    if (library[x, 0] == 1)
                    {
                        library[x, 1] = 1;
                        if (library[x, 1] == 1 && y > 1)
                        {
                            int a = rnd.Next(0, 2);
                            if (a == 0 && x > 1 && y < 29 && library[x, y] == 1) // Yukarı
                            {
                                library[x - 1, y] = 1;
                                library[x - 1, y + 1] = 1;
                            }
                            else if (a == 1 && x < 29 && y < 29)
                            {
                                library[x + 1, y] = 1;
                                library[x + 1, y + 1] = 1;
                            }
                            else if (a == 2 && y < 28)
                            {
                                library[x, y + 1] = 1;
                                library[x, y + 2] = 1;
                            }
                            if (y == 29 && library[x, y - 1] == 1)
                            {
                                library[x, y] = 1;
                            }
                            else if (x == 29 && library[x - 1, y] == 1)
                            {
                                library[x, y] = 1;
                            }
                            else if (y == 3 && library [x,y-1] == 1)
                            {
                                library[x, y] = 1;
                            }
                        }
                    }
                    else
                    {
                        for (int a = 1; a < 29; a++)
                        {
                            for (int b = 1; b < 29; b++)
                            {
                                if ((library[a + 1, b + 1] == 1 && library[a, b + 1] == 1 && library[a + 1, b] == 1) || (library[a - 1, b - 1] == 1 && library[a, b - 1] == 1 && library[a - 1, b] == 1))
                                {

                                }
                                else
                                {
                                    int p = rnd.Next(0, 100);
                                    if (p < 30)
                                    {
                                        library[a, b] = 1;
                                        
                                    }
                                    else
                                    {
                                        library[a, b] = 0;
                                    }
                                }
                            }
                        }
                    }
                    Console.Write(library[x,y]+ "  ");
                }
            }
        }
    }
}
