using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Days
{
    class Day1
    {
        public static string dataFile = "problems/day1-part1.txt";
        public static List<int> depths = new List<int>();

        private static void ReadData()
        {
            var data = File.ReadAllLines(dataFile).ToArray();
            foreach (string line in data)
            {
                depths.Add(int.Parse(line));
            }
        }

        public static void SolveProblem()
        {
            ReadData();

            var currentDepth = depths[0];
            var timesIncreased = 0;
            Console.WriteLine($"There are a total of {depths.Count} depths");

            for (int i=1; i<depths.Count; i++) 
            {
                if (depths[i] > currentDepth)
                {
                    timesIncreased += 1;
                }
                currentDepth = depths[i];
            }

            Console.WriteLine($"The depth increased {timesIncreased} times");
        }
    }
}
