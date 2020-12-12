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

        private static bool IsValidNumber(long number, Span<long> prevNums)
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

        private static (long Number, int Index) GetFirstInvalidNumberAndIndex(long[] inputValues, int preambleLength)
        {
            for (int i = preambleLength, offset = 0, length = inputValues.Length; i < length; i++, offset++)
            {
                if (!IsValidNumber(inputValues[i], inputValues.AsSpan(offset, preambleLength)))
                {
                    return (inputValues[i], i);
                }
            }
            return (0, -1);
        }

        private static void RunPart1(long[] inputValues)
        {
            const int PreambleLength = 25;
            long result = GetFirstInvalidNumberAndIndex(inputValues, PreambleLength).Number;

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], new string[] { result.ToString() });
        }

        private static (long Min, long Max) GetMinMax(ReadOnlySpan<long> numbers)
        {
            (long min, long max) = (
                Math.Min(numbers[0], numbers[1]),
                Math.Max(numbers[0], numbers[1]));

            for (int i = 2, length = numbers.Length; i < length; i++)
            {
                ref readonly long number = ref numbers[i];

                if (number > max)
                {
                    max = number;
                }
                if (number < min)
                {
                    min = number;
                }
            }
            return (min, max);
        }

        private static long? TryGetEncryptionWeakness(long invalidNumber, ReadOnlySpan<long> inputSlice)
        {
            long sum = 0;

            for (int i = 0, length = inputSlice.Length; i < length; i++)
            {
                sum += inputSlice[i];

                if (sum == invalidNumber)
                {
                    (long min, long max) = GetMinMax(inputSlice.Slice(0, i + 1));
                    return min + max;
                }
                if (sum > invalidNumber)
                {
                    return null;
                }
            }
            return null;
        }

        private static long GetEncryptionWeakness((long Number, int Index) invalidNumAndIndex, long[] inputValues)
        {
            for (int i = 0, length = invalidNumAndIndex.Index; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    ReadOnlySpan<long> slice = inputValues.AsSpan(i, length - j);
                    long? possibleEncryptionWeakness = TryGetEncryptionWeakness(invalidNumAndIndex.Number, slice);

                    if (possibleEncryptionWeakness.HasValue)
                    {
                        long encryptionWeakness = possibleEncryptionWeakness.GetValueOrDefault();
                        return encryptionWeakness;
                    }
                }
                ;
            }
            return 0;
        }

        private static void RunPart2(long[] inputValues)
        {
            const int PreambleLength = 25;
            (long, int) invalidNumAndIndex = GetFirstInvalidNumberAndIndex(inputValues, PreambleLength);
            long result = GetEncryptionWeakness(invalidNumAndIndex, inputValues);

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[1], new string[] { result.ToString() });
        }

        public static void Run()
        {
            long[] inputValues = Array.ConvertAll(
                PuzzleIOManager.ReadTextLines(RelativeInputPath), s => long.Parse(s));

            RunPart1(inputValues);
            RunPart2(inputValues);
        }
    }
}