using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day7
    {
        public static readonly string RelativeInputPath = "Day7/input.txt";

        public static readonly string[] RelativeOutputPaths =
        {
            "Day7/output1.txt",
            "Day7/output2.txt",
        };

        private static readonly BagInfo ShinyGoldBag = new("shiny gold", 1, Array.Empty<BagInfo>());

        private static Dictionary<BagInfo, int> GetInitialBagsWithCounts(HashSet<BagInfo> inputValues)
        {
            Dictionary<BagInfo, int> result = new(inputValues.Count);

            foreach (BagInfo bag in inputValues)
            {
                int bagContentsLength = bag.Contents.Length;

                if (bagContentsLength == 0 || bag.Name == ShinyGoldBag.Name)
                {
                    result.Add(bag, 0);
                }
                else
                {
                    for (int i = 0; i < bagContentsLength; i++)
                    {
                        ref readonly BagInfo bagInContents = ref bag.Contents[i];

                        if (bagInContents.Name == ShinyGoldBag.Name)
                        {
                            result.TryAdd(bag, 1/*bagInContents.Count*/);
                            break;
                        }
                    }
                    if (!result.ContainsKey(bag))
                    {
                        result.Add(bag, -1);
                    }
                }
            }
            return result;
        }

        private static int GetCount(BagInfo bag, HashSet<BagInfo> inputValues, Dictionary<BagInfo, int> bagsWithCounts)
        {
            if (bagsWithCounts[bag] != -1)
            {
                return bagsWithCounts[bag];
            }

            inputValues.TryGetValue(bag, out BagInfo resultBag);
            int bagContentsLength = resultBag.Contents.Length;

            if (bagContentsLength > 0)
            {
                for (int i = 0; i < bagContentsLength; i++)
                {
                    int count;

                    if (resultBag.Contents[i].Name == ShinyGoldBag.Name)
                    {
                        return 1;
                    }
                    else
                    {
                        count = GetCount(resultBag.Contents[i], inputValues, bagsWithCounts);
                    }
                    if (count != 0)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        private static void UpdateBagCounts(Dictionary<BagInfo, int> bagsWithCounts, HashSet<BagInfo> inputValues)
        {
            foreach (BagInfo bagWithoutSpecifiedCount in inputValues)
            {
                if (bagsWithCounts[bagWithoutSpecifiedCount] == -1)
                {
                    bagsWithCounts[bagWithoutSpecifiedCount] = GetCount(bagWithoutSpecifiedCount, inputValues, bagsWithCounts);
                }
            }
        }

        private static void RunPart1(HashSet<BagInfo> inputValues)
        {
            Dictionary<BagInfo, int> bagsWithCounts = GetInitialBagsWithCounts(inputValues);
            UpdateBagCounts(bagsWithCounts, inputValues);

            int result = bagsWithCounts.Sum(kv => kv.Value);
            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[0], new string[] { result.ToString() });
        }

        private static void RunPart2(BagInfo[] inputValues)
        {
            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[1], new string[] { default /*result*/ });
        }

        private static HashSet<BagInfo> GetInputValues(string[] inputLines)
        {
            var result = new HashSet<BagInfo>(inputLines.Length);

            for (int i = 0, length = inputLines.Length; i < length; i++)
            {
                result.Add(BagInfo.Parse(inputLines[i]));
            }
            return result;
        }

        public static void Run()
        {
            string[] inputLines = PuzzleIOManager.ReadTextLines(RelativeInputPath);
            HashSet<BagInfo> inputValues = GetInputValues(inputLines);

            RunPart1(inputValues);
            // RunPart2(inputValues);
        }
    }
}