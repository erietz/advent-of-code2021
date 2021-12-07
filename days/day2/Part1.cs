using System;
using System.IO;

namespace AdventOfCode.Days

{
    class Day2
    {
        public static string[] ReadData()
        {
            var data = File.ReadAllLines("problems/day2-part1.txt").ToArray();
            return data;
        }

        public static void Solve()
        {
            var data = ReadData();
            var depth = 0;
            var position = 0;

            foreach (var line in data)
            {
                var tmp = line.Split(" ");
                var direction = tmp[0];
                var magnitude = tmp[1];

                if (direction == "forward")
                {
                    position += int.Parse(magnitude);
                } else if (direction == "down")
                {
                    depth += int.Parse(magnitude);
                } else if (direction == "up")
                {
                    depth -= int.Parse(magnitude);
                }
            }
            Console.WriteLine("Depth: {0} Position: {1}", depth, position);
            Console.WriteLine("Depth * Position = {0}", depth*position);
        }
    }
}
