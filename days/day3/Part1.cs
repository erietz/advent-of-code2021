using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Days
{
    class Day3
    {
        public static List<List<int>> data = new List<List<int>>();

        static Day3()
        {
            var inputFile = "problems/day3-part1.txt";
            foreach (var line in File.ReadAllLines(inputFile))
            {
                var bits = new List<int>();
                foreach (char bit in line)
                {
                    bits.Add(int.Parse(bit.ToString()));
                }
                data.Add(bits);
            }
        }
        public static void PrintData()
        {
            foreach (var bitlist in data)
            {
                Console.WriteLine(String.Join(" ", bitlist));
            }
        }

        public static void SolvePart1()
        {
            var numDataPoints = data.Count();
            var numBits = data[0].Count();

            int[] mostCommonBit = new int[numBits];
            int[] leastCommonBit = new int[numBits];

            // sum 2*bit for each data point and store in mostCommonBit
            //
            // 2*bit is to avoid floating points numbers by having to divide by
            // 2
            foreach (var bitlist in data)
            {
                for (int i=0; i<numBits; i++)
                {
                    mostCommonBit[i] += 2*bitlist[i];
                }
            }

            /* Console.WriteLine(numDataPoints); */
            /* Console.WriteLine(String.Join(" ", mostCommonBit)); */

            for (int i=0; i<numBits; i++)
            {

                if (mostCommonBit[i] > numDataPoints)
                {
                    mostCommonBit[i] = 1;
                    leastCommonBit[i] = 0;
                } else if (mostCommonBit[i] < numDataPoints)
                {
                    mostCommonBit[i] = 0;
                    leastCommonBit[i] = 1;
                } else
                {
                    Console.WriteLine("There is no significant bit");
                }
            }

            var mostCommonBitAsString = String.Join("", mostCommonBit);
            var leastCommonBitAsString = String.Join("", leastCommonBit);
            Console.WriteLine($"mostCommonBitAsString: {mostCommonBitAsString}");
            Console.WriteLine($"leastCommonBitAsString: {leastCommonBitAsString}");

            uint gamma = Convert.ToUInt32(mostCommonBitAsString, 2);
            uint epsilon = Convert.ToUInt32(leastCommonBitAsString, 2);

            Console.WriteLine($"Gamma * epision = powerConsumption = {gamma}*{epsilon} = {gamma * epsilon}");

        }
    }
}
