using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public static class Day6
    {
        public static readonly string RelativeInputPath = "Day6/input.txt";

        public static readonly string[] RelativeOutputPaths =
        {
            "Day6/output1.txt",
            "Day6/output2.txt",
        };

        private static void RunPart1(List<ReadOnlyMemory<string>> inputValues)
        {
            int result = 0;

            for (int i = 0, length = inputValues.Count; i < length; i++)
            {
                result += QuestionnaireGroup.Parse(inputValues[i].Span)
                    .AnyCommonAnswers
                    .AnsweredQuestionCount();
            }

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], new string[] { result.ToString() });
        }

        private static void RunPart2(List<ReadOnlyMemory<string>> inputValues)
        {
            int result = 0;

            for (int i = 0, length = inputValues.Count; i < length; i++)
            {
                result += QuestionnaireGroup.Parse(inputValues[i].Span)
                    .AllCommonAnswers
                    .AnsweredQuestionCount();
            }

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[1], new string[] { result.ToString() });
        }

        public static List<ReadOnlyMemory<string>> GetInputValues(string[] inputLines)
        {
            List<ReadOnlyMemory<string>> result = new(inputLines.Length);
            int groupIndex = 0;
            int inputLength = inputLines.Length;

            for (int i = 0; i < inputLength; i++)
            {
                if (inputLines[i].Length == 0)
                {
                    result.Add(inputLines.AsMemory(groupIndex, i - groupIndex));
                    groupIndex = i + 1;
                }
            }
            result.Add(inputLines.AsMemory(groupIndex, inputLength - groupIndex));
            return result;
        }

        public static void Run()
        {
            string[] inputLines = PuzzleIOManager.ReadTextLines(RelativeInputPath);
            List<ReadOnlyMemory<string>> inputValues = GetInputValues(inputLines);

            RunPart1(inputValues);
            RunPart2(inputValues);
        }
    }
}