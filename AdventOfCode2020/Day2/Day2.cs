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
            int validPasswordInfosCount = inputValues.Where(passInfo =>
            {
                string pass = passInfo.PossibleCorruptedPassword;
                char reqChar = passInfo.RequiredCharacter;

                if (passInfo.MaxRequiredCharacterCount > pass.Length)
                {
                    return false;
                }
                int firstPos = passInfo.MinRequiredCharacterCount - 1;
                int secondPos = passInfo.MaxRequiredCharacterCount - 1;

                return pass[firstPos] == reqChar && pass[secondPos] != reqChar || 
                    pass[firstPos] != reqChar && pass[secondPos] == reqChar;
            }).Count();

            PuzzleIOManager.SaveTextLines(
                RelativeOutputPaths[1], new string[] { validPasswordInfosCount.ToString() });
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