using System.Collections.Generic;

namespace Day2
{
    class Game
    {
        public List<int> Red { get; set; } = new();
        public List<int> Blue { get; set; } = new();
        public List<int> Green { get; set; } = new();

        public Game() { }
        public Game(string gameString) 
        {
            foreach (var cubes in gameString.Split(';'))
            {
                foreach (var round in cubes.Split(','))
                {
                    if (round.Contains("blue"))
                    {
                        Blue.Add(int.Parse(round.Trim().Substring(0, round.Trim().IndexOf(' ')+1)));
                    }
                    else if (round.Contains("red"))
                    {
                        Red.Add(int.Parse(round.Trim().Substring(0, round.Trim().IndexOf(' ')+1)));
                    }
                    else if (round.Contains("green"))
                    {
                        Green.Add(int.Parse(round.Trim().Substring(0, round.Trim().IndexOf(' ')+1)));
                    }
                }
            }
            
        }
    }
}
