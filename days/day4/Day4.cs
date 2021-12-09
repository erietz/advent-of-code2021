using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Day4
    {
        public static List<int> numbers = new List<int>();
        public static List<int[,]> boards = new List<int[,]>();
        public static List<int[,]> boardsFilled = new List<int[,]>();

        static Day4()
        {
            Console.WriteLine("Constructor called");

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
                    boards.Add(board);
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

            for (int x=0; x<boards.Count(); x++)
            {
                boardsFilled.Add(new int[5,5]);
            }
        }

        public static void ResetBoards()
        {
            for (int i=0; i<boards.Count(); i++)
            {
                for (int j=0; j<5; j++)
                {
                    for (int k=0; k<5; k++)
                    {
                        boardsFilled[i][j,k] = 0;
                    }
                }
            }
        }

        public static void PrintBoards()
        {
            for (int i=0; i<boards.Count(); i++)
            {
                for (int j=0; j<5; j++)
                {
                    for (int k=0; k<5; k++)
                    {
                        /* Console.Write("{0} ", boards[i][j,k]); */
                        Console.Write("{0} ", boardsFilled[i][j,k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public static bool BoardIsWinner(int boardIndex)
        {
            var board = boardsFilled[boardIndex];

            var rowTotal = 0;
            for (int i=0; i<5; i++)
            {
                for (int j=0; j<5; j++)
                {
                    if (board[i, j] == 1)
                    {
                        rowTotal += 1;
                    }
                }
                if (rowTotal == 5)
                {
                    return true;
                }
                rowTotal = 0;
            }

            var columnTotal = 0;
            for (int j=0; j<5; j++)
            {
                for (int i=0; i<5; i++)
                {
                    if (board[i, j] == 1)
                    {
                        columnTotal += 1;
                    }
                }
                if (columnTotal == 5)
                {
                    return true;
                }
                columnTotal = 0;
            }

            return false;
        }

        public static void CalculateAnswer(int num, int boardIndex)
        {
            int sum = 0;
            for (int i=0; i<5; i++)
            {
                for (int j=0; j<5; j++)
                {
                    var value = boardsFilled[boardIndex][i,j];
                    if (value == 0)
                    {
                        sum += boards[boardIndex][i,j];
                    }
                }
            }
            Console.WriteLine("The solution is {0} * {1} = {2}", sum, num, sum * num);
        }

        public static void PlayBingo()
        {
            foreach (var num in numbers)
            {
                for (int i=0; i<boards.Count(); i++)
                {
                    for (int j=0; j<5; j++)
                    {
                        for (int k=0; k<5; k++)
                        {
                            if (boards[i][j,k] == num)
                            {
                                boardsFilled[i][j,k] = 1;
                            }
                        }
                    }
                    if (BoardIsWinner(i))
                    {
                        CalculateAnswer(num, i);
                        return;
                    }
                }
            }
        }

        public static void FindLastBoardToWin()
        {

            var winners = new List<int>();
            for (int i=0; i<boards.Count(); i++)
            {
                winners.Add(0);
            }

            /* PrintBoards(); */
            ResetBoards();
            /* Console.WriteLine("Boards have been reset"); */
            /* PrintBoards(); */

            int lastNumber=-1, lastBoardIndex=-1;
            foreach (var num in numbers)
            {
                for (int i=0; i<boards.Count(); i++)
                {
                    for (int j=0; j<5; j++)
                    {
                        for (int k=0; k<5; k++)
                        {
                            if (boards[i][j,k] == num)
                            {
                                boardsFilled[i][j,k] = 1;
                            }
                        }
                    }
                    if (BoardIsWinner(i))
                    {
                        winners[i] = 1;
                        lastBoardIndex = i;
                        lastNumber = num;
                        if (winners.Sum() == boards.Count())
                        {
                            Console.WriteLine("lastNumber {0} lastBoardIndex {1}", lastNumber, lastBoardIndex);
                            CalculateAnswer(lastNumber, lastBoardIndex);
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("lastNumber {0} lastBoardIndex {1}", lastNumber, lastBoardIndex);
            CalculateAnswer(lastNumber, lastBoardIndex);
        }

    }
}
