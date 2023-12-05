using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day3
{
    class Program
    {
        private static char[,] coordinates;
        private static readonly int size = 12;
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2023");
            var fileStream = new FileStream(@"C:\Users\frisk\source\repos\AdventOfCode2023\Day3\puzzledata.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                coordinates = new char[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        coordinates[i, j] = '.';
                    }
                }
                string line;
                var lineNr = 1;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {
                        for (int c = 0; c < line.Length; c++)
                        {
                            coordinates[lineNr, c+1] = line[c];
                        }
                        lineNr++;
                    }
                }
            }
            Console.WriteLine("Day 3, part 1: " + GetSumForSymbolAdjecentNumbers());
        }

        private static int GetSumForSymbolAdjecentNumbers()
        {
            var adjecentNumbersCoordinates = new List<(int, int)>();
            for (var row = 1; row < size-1; row++)
            {
                for (var column = 1; column < size-1; column++)
                {
                    //if we find a number
                    if (char.IsDigit(coordinates[row, column]))
                    {
                        //check all neighbours 
                        if (
                            (!char.IsDigit(coordinates[row-1, column-1]) && !coordinates[row-1, column-1].Equals('.')) ||
                            (!char.IsDigit(coordinates[row-1, column]) && !coordinates[row-1, column].Equals('.')) ||
                            (!char.IsDigit(coordinates[row-1, column+1]) && !coordinates[row-1, column+1].Equals('.')) ||
                            (!char.IsDigit(coordinates[row, column-1]) && !coordinates[row, column-1].Equals('.')) ||
                            (!char.IsDigit(coordinates[row, column+1]) && !coordinates[row, column+1].Equals('.')) ||
                            (!char.IsDigit(coordinates[row+1, column-1]) && !coordinates[row+1, column-1].Equals('.')) ||
                            (!char.IsDigit(coordinates[row+1, column]) && !coordinates[row+1, column].Equals('.')) ||
                            (!char.IsDigit(coordinates[row+1, column+1]) && !coordinates[row + 1, column + 1].Equals('.')) 
                            )
                        {
                            adjecentNumbersCoordinates.Add((row, column));
                        }
                    }
                }
            }
            return GetNumbersAtCoordinates(adjecentNumbersCoordinates).Sum();
        }

        private static List<int> GetNumbersAtCoordinates(List<(int, int)> numberCoordinates)
        {
            var numbers = new List<int>();
            var countedCoordinates = new List<(int, int)>();
            foreach (var (row, column) in numberCoordinates)
            {
                var start = column;
                var number = "";
                for (var i = column; i > 0; i--)
                {
                    if (char.IsDigit(coordinates[row, i]))
                    {
                        start = i;
                    }
                    else 
                    {
                        break;
                    }
                }
                for (var i = start; i < size-1; i++)
                {
                    if (countedCoordinates.Contains((row, i)))
                    {
                        break;
                    }
                    else if (char.IsDigit(coordinates[row, i]))
                    {
                        number += coordinates[row, i];
                        countedCoordinates.Add((row, i));
                    }
                    else if(number.Length > 0)
                    {
                        numbers.Add(int.Parse(number));
                        break;
                    }
                }
            }
            return numbers;
        }

    }
}
