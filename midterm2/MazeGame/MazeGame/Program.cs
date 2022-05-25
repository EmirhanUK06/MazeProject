using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            char secenek;
            
            int dongu = 0;

                
            while (dongu == 0)
            {
                Console.WriteLine("\n\nProgramı ne amaçla kullanmak istiyorsun?\n1. Verdiğin labirenti çözmek.\n2. Bir labirent oluşturmak.\n3. Çıkış\n");
                secenek = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                switch (secenek)
                {
                    case '1':
                        DataRead dataRead = new DataRead();
                        dataRead.read();
                        Bombs bombs = new Bombs();

                        Position position = new Position();
                        position.playerpos();
                        Console.WriteLine("\n\nDoğru yolu görmek için: X\nBombaları görmek için: B\nOrijinal halini görmek için: L\n");
                        char option2 = Console.ReadKey().KeyChar;
                        Console.WriteLine("\n");
                        switch (option2)
                        {
                            case 'X':
                                position.show();
                                break;
                            case 'B':
                                position.Explosive();
                                break;
                            case 'L': 
                                for(int i= 0; i<30;i++)
                                {
                                    Console.WriteLine("\n");
                                    for(int j=0; j<30;j++)
                                    {
                                        Console.Write(dataRead.Maze3[i,j] + "  ");
                                    }
                                }
                                break;
                            default: Console.WriteLine("\nLütfen geçerli bir değer verin.");
                                break;
                        }
                        break;
                    case '2':
                        Creator creator = new Creator();
                        creator.creator();
                        break;

                    case '3':
                        dongu = 1;
                        break;
                    default:
                        Console.WriteLine("Lütfen geçerli bir değer verin.");
                        break;
                }
            }
        }
    }
}
