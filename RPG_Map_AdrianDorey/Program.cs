using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        static string[,] mapLegend = new string[,]
        {
            {"^","Mountain"},
            {"`","Grass"},
            {"~","Water"},
            {"*","Trees"},
        };

        // usage: map[y, x]

        static int numRows = map.GetLength(0);
        static int numCols = map.GetLength(1);

        static void Main(string[] args)
        {
            Console.WriteLine("RPG Map - Adrian Dorey");
            Console.WriteLine();

            DisplayMap();
            Console.WriteLine();
            DisplayLegend();

            DisplayMap(2);
            Console.WriteLine();
            DisplayLegend();

            DisplayMap(3);
            Console.WriteLine();
            DisplayLegend();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        static void DisplayMap()
        {
            for (int row = 0; row < numRows + 2; row++)
            {
                for (int col = 0; col < numCols + 2; col++)
                {
                    if (row == 0 || row == numRows + 1)
                    {
                        if (col == 0 || col == numCols + 1)
                        {
                            Console.Write("+");
                        }
                        else
                        {
                            Console.Write("-");
                        }
                    }
                    else
                    {
                        if (col == 0 || col == numCols + 1)
                        {
                            Console.Write("|");
                        }
                        else
                        {
                            char c = map[row - 1, col - 1];
                            MapColor(c); //colors the characters specific colours.

                            Console.Write(map[row - 1, col - 1]);
                            Console.ResetColor();

                        }
                    }
                }
                Console.WriteLine();
            }
        }

        static void DisplayMap(int scale)
        {
            for (int row = 0; row < numRows + 2; row++)
            {
                for (int m = 0; m < scale; m++)
                {
                    for (int col = 0; col < numCols + 2; col++)
                    {
                        if (row == 0 || row == numRows + 1)
                        {
                            m = scale - 1; // using this so it only replicates the border once on the top and bottom
                    
                            if (col == 0 || col == numCols + 1)
                            {
                                Console.Write("+");
                            }
                                
                            else
                            {
                                for (int k = 0; k < scale; k++)
                                {
                                    Console.Write("-");
                                }
                            }
                        }

                        else
                        {
                            if (col == 0 || col == numCols + 1)
                            {
                                Console.Write("|");
                            }
                            else
                            {
                                for (int i = 0; i < scale; i++)
                                {
                                    char c = map[row - 1, col - 1];
                                    MapColor(c); //colors the characters specific colours.

                                    Console.Write(map[row - 1, col - 1]);
                                    Console.ResetColor();
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        static void MapColor(char c)
        {
            if (c == '~')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else if (c == '*')
            {
                Console.ForegroundColor = ConsoleColor.Yellow; //trees are yellow now?
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else if (c == '`')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Green;
            }
            else if (c == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
        }

        static void LegendColor(ConsoleColor colour, string mapItem, string mapPlace)
        {
            Console.ForegroundColor = colour;
            Console.BackgroundColor = colour;
            Console.Write(mapItem);
            Console.ResetColor();
            Console.WriteLine(mapPlace);
        }

        static void DisplayLegend()
        {
            Console.WriteLine("Map Legend:");

            LegendColor(ConsoleColor.DarkGray, "^", " = Mountain");
            LegendColor(ConsoleColor.Green, "`", " = Grass");
            LegendColor(ConsoleColor.Blue, "~", " = Water");
            LegendColor(ConsoleColor.Yellow, "*", " = Trees");
            Console.WriteLine();
        }
    }
}
