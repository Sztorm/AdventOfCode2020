namespace AdventOfCode2020
{
    public static class PassportDataValidator
    {
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
