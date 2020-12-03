using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day3
    {
        public static readonly string RelativeInputPath = "Day3/input.txt";

        public static readonly string[] RelativeOutputPaths =
        {
            "Day3/output1.txt",
            "Day3/output2.txt",
        };

        private static int CountTreesOnSlope(char[][] map, (int row, int column) displacement)
        {
            int rows = map.Length;
            int columns = rows > 0 ? map[0].Length : 0;
            (int row, int column) currentPosition = (0, 0);
            int treeCount = 0;

            for (int i = 0; currentPosition.row + displacement.row < rows; i += displacement.row)
            {
                currentPosition = (
                    currentPosition.row + displacement.row,
                    (currentPosition.column + displacement.column) % columns);
                if (map[currentPosition.row][currentPosition.column] == '#')
                {
                    treeCount++;
                }
            }
            return treeCount;
        }

        private static void RunPart1(char[][] inputValues)
        {
            int treeCount = CountTreesOnSlope(inputValues, (1, 3));

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], new string[] { treeCount.ToString() });
        }

        private static void RunPart2(char[][] inputValues)
        {
            Span<int> treeCounts = stackalloc int[]
            {
                CountTreesOnSlope(inputValues, (1, 1)),
                CountTreesOnSlope(inputValues, (1, 3)),
                CountTreesOnSlope(inputValues, (1, 5)),
                CountTreesOnSlope(inputValues, (1, 7)),
                CountTreesOnSlope(inputValues, (2, 1)),
            };
            long treeCountsProduct = treeCounts.Product();

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[1], new string[] { treeCountsProduct.ToString() });
        }

        public static void Run()
        {
            char[][] inputValues = PuzzleIOManager
                .ReadTextLines(RelativeInputPath)
                .Select(s => s.ToArray())
                .ToArray();

            RunPart1(inputValues);
            RunPart2(inputValues);
        }
    }
}