using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Day4
    {
        public static List<int> numbers = new List<int>();
        public static List<int[]> boards = new List<int[]>();

        static Day4()
        {
            string inputFile = "problems/day4.txt";
            var lines = File.ReadAllLines(inputFile);

            var tmpNumbers = new List<int>();
            foreach (var number in lines[0].Split(","))
            {
                tmpNumbers.Add(Int32.Parse(number));
            }
            numbers = tmpNumbers;

            int[,] board = new int[5,5];
            int i = 0;
            foreach (var line in lines.Skip(2).Take(lines.Count() - 1))
            {
                if (line == "")
                {
                    board = new int[5,5];
                    i = 0;
                    continue;
                } else
                {
                    var nums = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    for (int j=0; j<nums.Count(); j++)
                    {
                        board[i,j] = nums[j];
                        /* Console.WriteLine("i {0} j {1} board[i,j] {2}", i, j, board[i,j]); */
                    }
                    i += 1;
                }
            }
        }

        public static void Foo()
        {
        }
    }
}
