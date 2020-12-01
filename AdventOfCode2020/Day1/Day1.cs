using System;

namespace AdventOfCode2020
{
    public static class Day1
    {
        public static string RelativeInputPath => "Day1/input.txt";

        public static string RelativeOutputPath => "Day1/output.txt";

        public static void Run()
        {
            PuzzleIOManager.SaveTextLines(RelativeOutputPath, new string[] { "a", "ab", "cd4" });
        }
    }
}
