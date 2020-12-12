using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day9
    {
        public static readonly string RelativeInputPath = "Day9/input.txt";

        public static readonly string[] RelativeOutputPaths =
        {
            "Day9/output1.txt",
            "Day9/output2.txt",
        };

        private static bool IsValidValue(long number, Span<long> prevNums)
        {
            for (int i = 0, length = prevNums.Length; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (number == prevNums[i] + prevNums[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static long GetFirstInvalidNumber(long[] inputValues, int preambleLength)
        {
            for (int i = preambleLength, offset = 0, length = inputValues.Length; i < length; i++, offset++)
            {
                if (!IsValidValue(inputValues[i], inputValues.AsSpan(offset, preambleLength)))
                {
                    return inputValues[i];
                }
            }
            return 0;
        }

        private static void RunPart1(long[] inputValues)
        {
            const int preableLength = 25;
            long result = GetFirstInvalidNumber(inputValues, preableLength);

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], new string[] { result.ToString() });
        }

        private static void RunPart2(long[] inputValues)
        {
            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[1], new string[] { default /*result*/ });
        }

        public static void Run()
        {
            long[] inputValues = Array.ConvertAll(
                PuzzleIOManager.ReadTextLines(RelativeInputPath), s => long.Parse(s));

            RunPart1(inputValues);
            // RunPart2(inputValues);
        }
    }
}