using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    using static PassportDataValidator;

    public readonly struct PassportData
    {
        private const string BirthYearKey = "byr";
        private const string IssueYearKey = "iyr";
        private const string ExpirationYearKey = "eyr";
        private const string HeightKey = "hgt";
        private const string HairColorKey = "hcl";
        private const string EyeColorKey = "ecl";
        private const string PassportIDKey = "pid";
        private const string CountryIDKey = "cid";
        private static readonly Regex PassportDataRegex = new Regex(@"([a-z]+):([#a-z0-9]+)");

        public readonly string? BirthYear;
        public readonly string? IssueYear;
        public readonly string? ExpirationYear;
        public readonly string? Height;
        public readonly string? HairColor;
        public readonly string? EyeColor;
        public readonly string? PassportID;
        public readonly string? CountryID;

        public PassportData Validated => new(
            IsValidBirthYear(BirthYear) ? BirthYear : null,
            IsValidIssueYear(IssueYear) ? IssueYear : null,
            IsValidExpirationYear(ExpirationYear) ? ExpirationYear : null,
            IsValidHeight(Height) ? Height : null,
            IsValidHairColor(HairColor) ? HairColor : null,
            IsValidEyeColor(EyeColor) ? EyeColor : null,
            IsValidPassportID(PassportID) ? PassportID : null,
            CountryID);

        public PassportData(
            string? birthYear = null,
            string? issueYear = null,
            string? expirationYear = null,
            string? height = null,
            string? hairColor = null,
            string? eyeColor = null,
            string? passportID = null,
            string? countryID = null)
        {
            BirthYear = birthYear;
            IssueYear = issueYear;
            ExpirationYear = expirationYear;
            Height = height;
            HairColor = hairColor;
            EyeColor = eyeColor;
            PassportID = passportID;
            CountryID = countryID;
        }

        public static PassportData Parse(string s)
        {
            const int KeyCount = 8;
            MatchCollection matches = PassportDataRegex.Matches(s);
            Dictionary<string, string> passportKeyValuePairs = new(KeyCount);

            for (int i = 0, count = matches.Count; i < count; i++)
            {
                GroupCollection groups = matches[i].Groups;
                passportKeyValuePairs.Add(groups[1].Value, groups[2].Value);
            }
            return GetParsedData(passportKeyValuePairs);
        }

        private static PassportData GetParsedData(Dictionary<string, string> parsedKeyValuePairs)
        {
            string? birthYear;
            string? issueYear;
            string? expirationYear;
            string? height;
            string? hairColor;
            string? eyeColor;
            string? passportID;
            string? countryID;
            parsedKeyValuePairs.TryGetValue(BirthYearKey, out birthYear);
            parsedKeyValuePairs.TryGetValue(IssueYearKey, out issueYear);
            parsedKeyValuePairs.TryGetValue(ExpirationYearKey, out expirationYear);
            parsedKeyValuePairs.TryGetValue(HeightKey, out height);
            parsedKeyValuePairs.TryGetValue(HairColorKey, out hairColor);
            parsedKeyValuePairs.TryGetValue(EyeColorKey, out eyeColor);
            parsedKeyValuePairs.TryGetValue(PassportIDKey, out passportID);
            parsedKeyValuePairs.TryGetValue(CountryIDKey, out countryID);

            return new PassportData(
                birthYear,
                issueYear,
                expirationYear,
                height,
                hairColor,
                eyeColor,
                passportID,
                countryID);
        }
    }
}
