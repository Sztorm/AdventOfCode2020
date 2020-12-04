using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public static class Day4
    {
        public static readonly string RelativeInputPath = "Day4/input.txt";

        public static readonly string[] RelativeOutputPaths =
        {
            "Day4/output1.txt",
            "Day4/output2.txt",
        };

        private static void RunPart1(List<string> inputValues)
        {
            int validQuasiPassportsCount = 0;

            for (int i = 0, count = inputValues.Count; i < count; i++)
            {
                PassportData passportData = PassportData.Parse(inputValues[i]);
                validQuasiPassportsCount += Convert.ToInt32(
                    PassportDataValidator.AreValidNorthPoleCredentials(passportData));
            }

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], new string[] { validQuasiPassportsCount.ToString() });
        }

        private static void RunPart2(List<string> inputValues)
        {
            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[1], new string[] { default /*result*/ });
        }

        private static List<string> GetInputValues(string[] inputLines)
        {
            List<string> result = new(inputLines.Length);
            StringBuilder inputValueBuilder = new(1024);

            for (int i = 0, length = inputLines.Length; i < length; i++)
            {
                if (inputLines[i].Length == 0)
                {
                    result.Add(inputValueBuilder.ToString());
                    inputValueBuilder.Clear();
                    continue;
                }
                inputValueBuilder.Append(inputLines[i]);
                inputValueBuilder.Append(' ');
            }
            result.Add(inputValueBuilder.ToString());

            return result;
        }

        public static void Run()
        {
            string[] inputLines = PuzzleIOManager.ReadTextLines(RelativeInputPath);
            List<string> inputValues = GetInputValues(inputLines);

            RunPart1(inputValues);
            //RunPart2(inputLines);
        }
    }
}