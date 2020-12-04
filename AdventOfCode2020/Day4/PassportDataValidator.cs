using System;

namespace AdventOfCode2020
{
    public static class PassportDataValidator
    {
        private static bool IsValidYear(string? year, int min, int max)
        {
            if (year is null ||
                year.Length != 4 ||
                !int.TryParse(year, out int issueYearValue))
            {
                return false;
            }
            return issueYearValue >= min && issueYearValue <= max;
        }

        public static bool IsValidBirthYear(string? birthYear)
            => IsValidYear(birthYear, 1920, 2002);

        public static bool IsValidIssueYear(string? issueYear)
            => IsValidYear(issueYear, 2010, 2020);

        public static bool IsValidExpirationYear(string? expYear)
            => IsValidYear(expYear, 2020, 2030);

        private static bool IsValidHeightInInches(ReadOnlySpan<char> height)
        {
            if (!IsDigit(height[0]) ||
                !IsDigit(height[1]) ||
                height[2] != 'i' ||
                height[3] != 'n')
            {
                return false;
            }
            int num = int.Parse(height.Slice(0, 2));
            return num >= 59 && num <= 76;
        }

        private static bool IsValidHeightInCentimeters(ReadOnlySpan<char> height)
        {
            if (!IsDigit(height[0]) ||
                !IsDigit(height[1]) ||
                !IsDigit(height[2]) ||
                height[3] != 'c' ||
                height[4] != 'm')
            {
                return false;
            }
            int num = int.Parse(height.Slice(0, 3));

            return num >= 150 && num <= 193;
        }

        public static bool IsValidHeight(string? height)
        {
            if (height is null)
            {
                return false;
            }
            if (height.Length == 4)
            {
                return IsValidHeightInInches(height.AsSpan());
            }
            if (height.Length == 5)
            {
                return IsValidHeightInCentimeters(height.AsSpan());
            }
            return false;
        }

        private static bool IsSmallLetterInLatinAlphabet(char value)
            => value >= 'a' && value <= 'z';

        private static bool IsDigit(char value) => value >= '0' && value <= '9';

        public static bool IsValidHairColor(string? hairColor)
        {
            if (hairColor is null || hairColor.Length != 7 || hairColor[0] != '#')
            {
                return false;
            }
            for (int i = 1; i < 7; i++)
            {
                if (!IsDigit(hairColor[i]) && !IsSmallLetterInLatinAlphabet(hairColor[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidEyeColor(string? eyeColor)
        {
            return eyeColor switch
            {
                null => false,
                "amb" or "blu" or "brn" or "gry" or "grn" or "hzl" or "oth" => true,
                _ => false,
            };
        }

        public static bool IsValidPassportID(string? pid)
        {
            if (pid is null || pid.Length != 9)
            {
                return false;
            }
            for (int i = 0; i < 9; i++)
            {
                if (!IsDigit(pid[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidPassport(PassportData passportData)
            => AreValidNorthPoleCredentials(passportData) &&
               passportData.CountryID is not null;

        public static bool AreValidNorthPoleCredentials(PassportData passportData)
            => passportData.BirthYear is not null &&
               passportData.IssueYear is not null &&
               passportData.ExpirationYear is not null &&
               passportData.Height is not null &&
               passportData.HairColor is not null &&
               passportData.EyeColor is not null &&
               passportData.PassportID is not null;
    }
}
