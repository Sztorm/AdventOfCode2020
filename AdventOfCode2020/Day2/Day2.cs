using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day2
    {
        public static readonly string RelativeInputPath = "Day2/input.txt";

        public static readonly string[] RelativeOutputPaths =
        {
            "Day2/output1.txt",
            "Day2/output2.txt",
        };

        private static void RunPart1(PasswordInfo[] inputValues)
        {
            int validPasswordInfosCount = inputValues.Where(passInfo =>
            {
                int reqCharCount = passInfo
                    .PossibleCorruptedPassword
                    .Count(c => c == passInfo.RequiredCharacter);

                return reqCharCount >= passInfo.MinRequiredCharacterCount && 
                    reqCharCount <= passInfo.MaxRequiredCharacterCount;
            }).Count();

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], new string[] { validPasswordInfosCount.ToString() });
        }

        private static void RunPart2(PasswordInfo[] inputValues)
        {
        }

        public static void Run()
        {
            PasswordInfo[] inputValues = PuzzleIOManager
                .ReadTextLines(RelativeInputPath)
                .Select(s => PasswordInfo.Parse(s))
                .ToArray();

            RunPart1(inputValues);
            RunPart2(inputValues);
        }
    }
}