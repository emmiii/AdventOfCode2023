using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2023");

            Dictionary<int, Game> games = new Dictionary<int, Game>();
            var fileStream = new FileStream(@"C:\Users\frisk\source\repos\AdventOfCode2023\Day2\puzzledata.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {
                        var id = int.Parse(line.Substring(5, line.IndexOf(':')-5));
                        games.Add(id, new Game(line.Substring(line.IndexOf(':') + 1)));
                    }
                    else
                    {

                    }
                }
            }

            var sumOfIdsOfPossibleGames = 0;
            foreach (var game in games)
            {
                if (PossibleGame(game.Value))
                {
                    sumOfIdsOfPossibleGames += game.Key;
                }
            }
            Console.WriteLine("Day 2, part 1: " + sumOfIdsOfPossibleGames);

        }


        // only 12 red cubes, 13 green cubes, and 14 blue cubes
        private const int redCubes = 12;
        private const int greenCubes = 13;
        private const int blueCubes = 14;

        private static bool PossibleGame(Game game)
        {
            if (game.Red.Max() > redCubes)
            { 
                return false;
            }
            if (game.Green.Max() > greenCubes)
            { 
                return false;
            }
            if (game.Blue.Max() > blueCubes)
            { 
                return false;
            }
            return true;
        }
    }
}
