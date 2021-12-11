using System;
using System.IO;
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
                    return;
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

        public static int[] GetMostCommon(List<List<int>> theData)
        {
            var numDataPoints = theData.Count();
            var numBits = theData[0].Count();

            int[] mostCommonBit = new int[numBits];

            // sum 2*bit for each data point and store in mostCommonBit
            //
            // 2*bit is to avoid floating points numbers by having to divide by
            // 2
            foreach (var bitlist in theData)
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

                if (mostCommonBit[i] >= numDataPoints)
                {
                    mostCommonBit[i] = 1;
                } else
                {
                    mostCommonBit[i] = 0;
                }
            }

            return mostCommonBit;
        }

        public static int[] GetLeastCommon(List<List<int>> theData)
        {
            var numDataPoints = theData.Count();
            var numBits = theData[0].Count();

            int[] leastCommonBit = new int[numBits];

            // sum 2*bit for each data point and store in mostCommonBit
            //
            // 2*bit is to avoid floating points numbers by having to divide by
            // 2
            foreach (var bitlist in theData)
            {
                for (int i=0; i<numBits; i++)
                {
                    leastCommonBit[i] += 2*bitlist[i];
                }
            }

            /* Console.WriteLine(numDataPoints); */
            /* Console.WriteLine(String.Join(" ", mostCommonBit)); */

            for (int i=0; i<numBits; i++)
            {

                if (leastCommonBit[i] < numDataPoints)
                {
                    leastCommonBit[i] = 1;
                } else
                {
                    leastCommonBit[i] = 0;
                }
            }
            return leastCommonBit;
        }

        public static int GetO2Rating()
        {
            var mostCommonBit = GetMostCommon(data);
            var remainingData = data;

            // loop through each bit
            for (int i=0; i<data[0].Count; i++)
            {
                var saveData = new List<List<int>>();

                // loop through data point
                foreach (var bitlist in remainingData)
                {
                    if (bitlist[i] == mostCommonBit[i])
                    {
                        saveData.Add(bitlist);
                    }
                }
                remainingData = saveData;
                mostCommonBit = GetMostCommon(remainingData);

                if (remainingData.Count == 1)
                {
                    var number = String.Join("", remainingData[0]);

                    return Convert.ToInt32(number, 2);
                }
            }

            return -1;
        }

        public static int GetCO2Rating()
        {
            var leastCommonBit = GetLeastCommon(data);
            var remainingData = data;

            // loop through each bit
            for (int i=0; i<data[0].Count; i++)
            {
                var saveData = new List<List<int>>();

                // loop through data point
                foreach (var bitlist in remainingData)
                {
                    if (bitlist[i] == leastCommonBit[i])
                    {
                        saveData.Add(bitlist);
                    }
                }
                remainingData = saveData;
                leastCommonBit = GetLeastCommon(remainingData);

                if (remainingData.Count == 1)
                {
                    var number = String.Join("", remainingData[0]);

                    return Convert.ToInt32(number, 2);
                }
            }

            return -1;
        }

        public static void SolvePart2()
        {
            var o2Rating = GetO2Rating();
            Console.WriteLine(String.Join("", o2Rating));

            var co2Rating = GetCO2Rating();
            Console.WriteLine(String.Join("", co2Rating));

            Console.WriteLine(
                    "O2 rating * CO2 rating = {0} * {1} = {2}",
                    o2Rating,
                    co2Rating,
                    o2Rating * co2Rating
                    );

        }
    }
}
