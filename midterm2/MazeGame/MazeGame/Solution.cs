using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Position
    {
        bool check = true;
        bool check2 = true;
        bool check3 = true;
        bool check4 = true;
        public string[,] matris = new string[30, 30];
        int x = 0, y = 0;
        int check5 = 0;
        DataRead dataRead = new DataRead();
        Bombs bombs = new Bombs();
        
        public void playerpos()
        {
            if (check == true)
            {
                dataRead.read();
                Console.WriteLine("\nLabirenti çözmeye başlıyorum.\n");
                System.Threading.Thread.Sleep(500);
                check = false;
            }

            for (x = 0; (x < 30); x++)
            {
                if (dataRead.Maze[x, y] == "0")
                {
                    dataRead.Maze[x, y] = "2";
                    control();

                }


            }

            exit();
            return;
        }

        public void control()
        {
            if (y == 29)
            {
                check2 = false;
            }

            else if ((y != 29) && dataRead.Maze[x, y + 1] == "0")
            {
                y++;
                dataRead.Maze[x, y] = "2";
            }


            else if ((x != 29) && dataRead.Maze[x + 1, y] == "0")
            {
                x++;
                dataRead.Maze[x, y] = "2";
            }
            else if ((x != 0) && dataRead.Maze[x - 1, y] == "0")
            {
                x--;
                dataRead.Maze[x, y] = "2";
            }

            else if ((y != 0) && dataRead.Maze[x, y - 1] == "0")
            {
                y--;
                dataRead.Maze[x, y] = "0";
            }

            else if ((y == 0) && (x != 0) && (dataRead.Maze[x, y + 1] == "1") && (dataRead.Maze[x + 1, y] == "1") && (dataRead.Maze[x - 1, y] == "1"))
            {
                dataRead.Maze[x, y] = "1";
                playerpos();
            }
            else if ((y == 0) && (x == 0) && (dataRead.Maze[x, y + 1] == "1") && (dataRead.Maze[x + 1, y] == "1"))
            {
                dataRead.Maze[x, y] = "1";
                playerpos();
            }

            else if (((y != 29) && dataRead.Maze[x, y + 1] == "2") || ((x != 29) && dataRead.Maze[x + 1, y] == "2") || ((x != 0) && dataRead.Maze[x - 1, y] == "2") || ((y != 0) && dataRead.Maze[x, y - 1] == "2"))
            {

                dataRead.Maze[x, y] = "1";

                if ((y != 29) && dataRead.Maze[x, y + 1] == "2")
                {
                    y++;
                }
                else if ((x != 29) && dataRead.Maze[x + 1, y] == "2")
                {
                    x++;
                }
                else if ((x != 0) && dataRead.Maze[x - 1, y] == "2")
                {
                    x--;
                }
                else if ((y != 0) && dataRead.Maze[x, y - 1] == "2")
                {
                    y--;
                }

            }
            else if (((y != 29) && dataRead.Maze[x, y + 1] == "1") && ((x != 29) && dataRead.Maze[x + 1, y] == "1") && ((x != 0) && dataRead.Maze[x - 1, y] == "1") && ((y != 0) && dataRead.Maze[x, y - 1] == "1"))
            {
                x = 0;
                y = 0;
                playerpos();
            }


            for (int i = 0; i < 30 && (check2 == true); i++)
            {
                control();
            }


        }

        public void exit()
        {
            bombs.bomb();
            y = 0;
            for (int a = 29; (a >= 0) && check3 == true; a--)
            {
                if (dataRead.Maze[a, 0] == "2")
                {
                    Console.Write("ÇIKIŞ BULUNDU!\n({0},0), ", a);
                    x = a;
                    dataRead.Maze[x, y] = "2";
                    check3 = false;
                }
            }


            for (int i = 0; i < 900 && check4 == true; i++)
            {   
                if (y == 29)
                {
                    for (int satır = 0; satır < 30; satır++)
                    {
                        for (int sütun = 0; sütun < 30; sütun++)
                        {
                            matris[satır, sütun] = dataRead.Maze2[satır, sütun];

                        }
                    }
                    check4 = false;

                }
                else if ((check5 != 4) && (y != 29) && dataRead.Maze[x, y + 1] == "2")
                {
                    y++;
                    check5 = 1;
                    Console.Write("({0},{1}), ", x, y);
                    dataRead.Maze2[x, y] = "2";

                }

                else if ((check5 != 3) && (x != 29) && dataRead.Maze[x + 1, y] == "2")
                {
                    x++;
                    check5 = 2;
                    Console.Write("({0},{1}), ", x, y);
                    dataRead.Maze2[x, y] = "2";

                }

                else if ((check5 != 2) && (x != 0) && dataRead.Maze[x - 1, y] == "2")
                {
                    x--;
                    check5 = 3;
                    Console.Write("({0},{1}), ", x, y);
                    dataRead.Maze2[x, y] = "2";

                }
                else if ((check5 != 1) && (y != 0) && dataRead.Maze[x, y - 1] == "2")
                {
                    y--;
                    check5 = 4;
                    Console.Write("({0},{1}), ", x, y);
                    dataRead.Maze2[x, y] = "2";

                }

            }
                if (matris[bombs.bombline[0],bombs.bombcolumn[0]] == "2" || matris[bombs.bombline[1], bombs.bombcolumn[1]] == "2" || matris[bombs.bombline[2], bombs.bombcolumn[2]] == "2")
                {
                    Console.WriteLine("Bomba patladı!");
                    Console.Beep(15000, 1500);
                    return;
                }
            //----------------------------------------------------------------
        }
        public void show()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < 30; j++)
                {
                    if (dataRead.Maze2[i, j] == "2")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (dataRead.Maze2[i, j] == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (dataRead.Maze2[i, j] == "0")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(dataRead.Maze2[i, j] + "  ");

                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public void Explosive()
        {
            exit();
            for (int k = 0; k < 3; k++)
            {
               Console.WriteLine("(" + bombs.bombline[k] + "," + bombs.bombcolumn[k] +")");
            }

            Console.WriteLine("Bombaların koordinatları yukarıdadır. Patlama durumunda uyarı geçer. Geri dönmek için bir tuşa basınız.\n");

                if (dataRead.Maze2[bombs.bombline[0],bombs.bombcolumn[0]] == "2" || dataRead.Maze2[bombs.bombline[1], bombs.bombcolumn[1]] == "2" || dataRead.Maze2[bombs.bombline[2], bombs.bombcolumn[2]] == "2")
                {
                    Console.ReadKey();
                    return;
                }
        }
    }
}

