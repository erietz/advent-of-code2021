using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode
{

    struct LineSegment 
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;

        public LineSegment(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
        public override string ToString() => $"({x1}, {y1}) -> ({x2}, {y2})";
    }

    class Day5
    {
        public static List<LineSegment> LineSegments = new List<LineSegment>();
        public static int MaxX = 0;
        public static int MaxY = 0;
        public static List<List<int>> diagram = new List<List<int>>();

        static Day5()
        {
            var fileName = "problems/day5.txt";
            foreach (var line in File.ReadAllLines(fileName))
            {
                var coordPairs = line.Split(" -> ");
                var coordsInitial = coordPairs[0].Split(",");
                var coordsFinal = coordPairs[1].Split(",");
                int x1 = int.Parse(coordsInitial[0]);
                int y1 = int.Parse(coordsInitial[1]);
                int x2 = int.Parse(coordsFinal[0]);
                int y2 = int.Parse(coordsFinal[1]);

                if (x1 == x2 || y1 == y2)
                {
                    LineSegments.Add(new LineSegment(x1, y1, x2, y2));
                    if (x1 > MaxX)
                    {
                        MaxX = x1;
                    } 
                    if (x2 > MaxX)
                    {
                        MaxX = x2;
                    }
                    if (y1 > MaxY)
                    {
                        MaxY = y1;
                    }
                    if (y2 > MaxY)
                    {
                        MaxY = y2;
                    }
                }
            }

            for (int x=0; x<=MaxX; x++)
            {
                var row = new List<int>();
                for (int y=0; y<=MaxY; y++)
                {
                    row.Add(0);
                }
                diagram.Add(row);
            }
        }

        public static void PrintSegments()
        {
            foreach (var segment in LineSegments)
            {
                Console.WriteLine(segment);
            }
        }

        public static void PrintDiagram ()
        {
            for (int x=0; x<diagram.Count; x++)
            {
                for (int y=0; y<diagram[0].Count; y++)
                {
                    Console.Write(diagram[y][x]);
                }
                Console.WriteLine();
            }
        }

        public static void FillDiagram()
        {
            foreach(var segment in LineSegments)
            {
                if (segment.x1 == segment.x2)
                {
                    if (segment.y2 > segment.y1)
                    {
                        for (int i=segment.y1; i<=segment.y2; i++)
                        {
                            diagram[segment.x1][i] += 1;
                        }
                    } 
                    else
                    {
                        for (int i=segment.y2; i<=segment.y1; i++)
                        {
                            diagram[segment.x1][i] += 1;
                        }
                    }
                } else if (segment.y1 == segment.y2)
                {
                    if (segment.x2 > segment.x1)
                    {
                        for (int i=segment.x1; i<=segment.x2; i++)
                        {
                            diagram[i][segment.y1] += 1;
                        }
                    }
                    else
                    {
                        for (int i=segment.x2; i<=segment.x1; i++)
                        {
                            diagram[i][segment.y1] += 1;
                        }
                    }
                }
            }
        }

        public static void SolvePart1()
        {
            FillDiagram();
            var dangerousAreas = 0;
            foreach (var row in diagram)
            {
                foreach (var col in row)
                {
                    if (col >= 2)
                    {
                        dangerousAreas += 1;
                    }
                }
            }
            Console.WriteLine("Number of dangerous areas = {0}", dangerousAreas);
            /* PrintDiagram(); */
        }
    }
}
