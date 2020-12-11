using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day8
    {
        public static readonly string RelativeInputPath = "Day8/input.txt";

        public static readonly string[] RelativeOutputPaths =
        {
            "Day8/output1.txt",
            "Day8/output2.txt",
        };

        private static void RunPart1(Instruction[] inputValues)
        {
            ConsoleInstructionInterpreter interpreter = new();
            int result = interpreter.Run(inputValues);

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], new string[] { result.ToString() });
        }

        private static void RunPart2(Instruction[] inputValues)
        {
            int result = 0;

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[1], new string[] { result.ToString() });
        }

        public static void Run()
        {
            string[] inputLines = PuzzleIOManager.ReadTextLines(RelativeInputPath);
            Instruction[] inputValues = InstructionParser.Parse(inputLines);

            RunPart1(inputValues);
            // RunPart2(inputValues);
        }
    }
}