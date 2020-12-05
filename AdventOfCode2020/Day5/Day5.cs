using System.Linq;

namespace AdventOfCode2020
{
    public static class Day5
    {
        public static readonly string RelativeInputPath = "Day5/input.txt";

        public static readonly string[] RelativeOutputPaths =
        {
            "Day5/output1.txt",
            "Day5/output2.txt",
        };

        private static void RunPart1(SeatInfo[] inputValues)
        {
            int result = inputValues.Max(seat => seat.ID);

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], new string[] { result.ToString() });
        }

        private static void RunPart2(SeatInfo[] inputValues)
        {
            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[1], new string[] { default /*result*/ });
        }

        public static void Run()
        {
            SeatInfo[] inputValues = PuzzleIOManager
                .ReadTextLines(RelativeInputPath)
                .Select(s => SeatInfo.Parse(s))
                .ToArray();

            RunPart1(inputValues);
            //RunPart2(inputValues);
        }
    }
}