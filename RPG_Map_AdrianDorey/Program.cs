using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Map_AdrianDorey
{
    internal class Program
    {
        static char[,] map = new char[,] // dimensions defined by following data: 12 rows, 30 columns
        {
            {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
            {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
            {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
            {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
            {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
            {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        };

        
        
        
        // usage: map[y, x]

        static int rows = map.GetLength(0);
        static int cols = map.GetLength(1);

        

        static void Main(string[] args)
        {
            Console.WriteLine("RPG Map - Adrian Dorey");
            Console.WriteLine();

            DisplayMap(2);
            Console.WriteLine();
            DisplayLegend();


            //DisplayMap(2);
            //Console.WriteLine();

            //DisplayMap(3);
            //Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        static void DisplayMap()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    

                    char c = map[i, j]; 
                    MapColor(c); //colors the characters specific colours.

                    Console.Write(map[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void DisplayMap(int scale)
        {
            
            
            for(int i = 0;i < rows*scale; i++)
            {
                for (int j = 0; j < cols * scale; j++)
                {
                    for (int k = 0; k < scale; k++)
                    {
                        Console.Write(map[i, j]);


                    }
                }
                Console.WriteLine();
            }
        }

       

        static void MapColor(char c)
        {
            if (c == '~')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (c == '*')
            {
                Console.ForegroundColor = ConsoleColor.Yellow; //trees are yellow now?
            }
            else if (c == '`')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (c == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }

        }

        static void DisplayLegend()
        {
            Console.WriteLine("Map Legend:");
            Console.WriteLine("^ = Mountain");
            Console.WriteLine("` = Grass");
            Console.WriteLine("~ = Water");
            Console.WriteLine("* = Trees");
        }
    }
}
