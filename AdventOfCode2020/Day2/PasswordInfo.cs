using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public readonly struct PasswordInfo
    {
        public readonly char RequiredCharacter;
        public readonly int MinRequiredCharacterCount;
        public readonly int MaxRequiredCharacterCount;
        public readonly string PossibleCorruptedPassword;

        public PasswordInfo(
            char reqChar, 
            int minReqCharcount, 
            int maxReqCharCount, 
            string possibleCorruptedPass)
        {
            RequiredCharacter = reqChar;
            MinRequiredCharacterCount = minReqCharcount;
            MaxRequiredCharacterCount = maxReqCharCount;
            PossibleCorruptedPassword = possibleCorruptedPass;
        }

        private static readonly Regex PassInfoRegex = new Regex(@"(\d+)-(\d+) ([a-z]): ([a-z]+)");

        public static PasswordInfo Parse(string s)
        {
            GroupCollection groups = PassInfoRegex.Match(s).Groups;  
            
            if (groups.Count != 5)
            {
                throw new FormatException(@"Wrong string format. The pattern is: ""\d+-\d+ [a-z]: [a-z]+""");
            }
            char reqChar = groups[3].Value[0];
            int minReqCharcount = int.Parse(groups[1].Value);
            int maxReqCharCount = int.Parse(groups[2].Value);
            string possibleCorruptedPass = groups[4].Value;

            return new PasswordInfo(reqChar, minReqCharcount, maxReqCharCount, possibleCorruptedPass);
        }

        public override string ToString() 
            => $"{MinRequiredCharacterCount}-{MaxRequiredCharacterCount} {RequiredCharacter}: {PossibleCorruptedPassword}";
    }
}
