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

        public static void SolvePart1()
        {
            var data = ReadData();
            var depth = 0;
            var position = 0;

            foreach (var line in data)
            {
                var tmp = line.Split(" ");
                var direction = tmp[0];
                var magnitude = int.Parse(tmp[1]);

                if (direction == "forward")
                {
                    position += magnitude;
                } else if (direction == "down")
                {
                    depth += magnitude;
                } else if (direction == "up")
                {
                    depth -= magnitude;
                }
            }
            Console.WriteLine("Depth: {0} Position: {1}", depth, position);
            Console.WriteLine("Depth * Position = {0}", depth*position);
        }

        public static void SolvePart2()
        {
            var data = ReadData();
            var depth = 0;
            var position = 0;
            var aim = 0;

            foreach (var line in data)
            {
                var tmp = line.Split(" ");
                var direction = tmp[0];
                var magnitude = int.Parse(tmp[1]);

                if (direction == "forward")
                {
                    position += magnitude;
                    depth += aim * magnitude;
                } else if (direction == "down")
                {
                    aim += magnitude;
                } else if (direction == "up")
                {
                    aim -= magnitude;
                }
            }
            Console.WriteLine("Depth: {0} Position: {1}", depth, position);
            Console.WriteLine("Depth * Position = {0}", depth*position);
        }
    }
}
