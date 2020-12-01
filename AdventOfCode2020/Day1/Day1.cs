using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day1
    {
        public static readonly string RelativeInputPath = "Day1/input.txt";

        public static readonly string[] RelativeOutputPaths =
        {
            "Day1/output1.txt",
            "Day1/output2.txt",
        };

        private static void RunPart1(int[] inputValues)
        {
            const int RequiredSumOfTwoValues = 2020;
            List<int> result = new();

            for (int i = 0, length = inputValues.Length; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    ref readonly int inputVal1 = ref inputValues[i];
                    ref readonly int inputVal2 = ref inputValues[j];

                    if (inputVal1 + inputVal2 == RequiredSumOfTwoValues)
                    {
                        result.Add(inputVal1 * inputVal2);
                    }
                }
            }
            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], result.Select(n => n.ToString()).ToArray());
        }

        public static void Run()
        {
            int[] inputValues = PuzzleIOManager
                .ReadTextLines(RelativeInputPath)
                .Select(s => int.Parse(s))
                .ToArray();

            RunPart1(inputValues);
        }
    }
}
