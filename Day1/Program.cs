using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2023");

            List<string> lines = new List<string>();
            var fileStream = new FileStream(@"C:\Users\frisk\source\repos\AdventOfCode2023\Day1\puzzledata.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {
                        lines.Add(line);
                    }
                    else
                    {

                    }
                }
            }

            var calibrationValues = new List<int>();
            foreach (var line in lines)
            {
                calibrationValues.Add(GetFirstInteger(line) * 10 + GetLastInteger(line));
            }
            var calibrationValues2 = new List<int>();
            foreach (var line in lines)
            {
                var transformedLine = ReplaceWrittenNumbersWithDigits(line);
                calibrationValues2.Add(GetFirstInteger(transformedLine) * 10 + GetLastInteger(transformedLine));
            }

            Console.WriteLine("Day 1, part 1: " + calibrationValues.Sum());
            Console.WriteLine("Day 1, part 2: " + calibrationValues2.Sum());
        }

        private static Dictionary<string, string> writtenNumbers = new() 
        { 
            {"one", "on1e" },
            {"two", "tw2o" },
            {"three", "thr3ee" },
            {"four", "fo4ur" },
            {"five", "fi5ve" },
            {"six", "si6x" },
            {"seven", "sev7en" },
            {"eight", "eig8ht" },
            {"nine", "ni9ne" },
        };

        private static string ReplaceWrittenNumbersWithDigits(string line)
        {
            var replacedLine = line;
            foreach (var number in writtenNumbers.Keys)
            {
                replacedLine = replacedLine.Replace(number.ToString(), writtenNumbers[number]);
            }
            return replacedLine;
        }

        private static int GetFirstInteger(string line)
        {
            foreach (char c in line)
            {
                if (char.IsDigit(c))
                {
                    return int.Parse(c.ToString());
                }
            }
            return 0;
        }

        private static int GetLastInteger(string line)
        {
            var charArray = line.ToCharArray();
            Array.Reverse(charArray);
            foreach (char c in charArray)
            {
                if (char.IsDigit(c))
                {
                    return int.Parse(c.ToString());
                }
            }
            return 0;
        }
    }
}
