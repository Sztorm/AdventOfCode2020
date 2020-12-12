using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day10
    {
        public static readonly string RelativeInputPath = "Day10/input.txt";

        public static readonly string[] RelativeOutputPaths =
        {
            "Day10/output1.txt",
            "Day10/output2.txt",
        };

        private static void RunPart1(int[] inputValues)
        {
            int oneJoltDiffs = 1;
            int threeJoltDiffs = 1;
            IOrderedEnumerable<int> sortedAdapterJoltages = inputValues.OrderBy(v => v);
            int prev = sortedAdapterJoltages.First();

            foreach (int joltage in sortedAdapterJoltages.Skip(1))
            {
                int diff = joltage - prev;

                if (diff == 1)
                {
                    oneJoltDiffs++;
                }
                else if (diff == 3)
                {
                    threeJoltDiffs++;
                }

                prev = joltage;
            }

            int result = oneJoltDiffs * threeJoltDiffs;
            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], new string[] { result.ToString() }); ;
        }

        private static void RunPart2(int[] inputValues)
        {
            int result = 0;

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[1], new string[] { result.ToString() });
        }

        public static void Run()
        {
            int[] inputValues = Array.ConvertAll(
                PuzzleIOManager.ReadTextLines(RelativeInputPath), s => int.Parse(s));

            RunPart1(inputValues);
            // RunPart2(inputValues);
        }
    }
}