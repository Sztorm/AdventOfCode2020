using System;

namespace AdventOfCode2020
{
    public readonly struct SeatInfo
    {
        public const int SeatRows = 128;
        public const int SeatColumns = 8;

        public int Row { get; }
        public int Column { get; }
        public int ID => Row * SeatColumns + Column;

        public SeatInfo(int row, int column) => (Row, Column) = (row, column);

        public override string ToString() => $"Row: {Row}, Column: {Column}, ID: {ID}";

        private static FormatException ParseFormatException
            => new FormatException("the provided string has wrong format. The string must have " +
                    "length of 10. The first seven characters should consist of F or B while " +
                    "the last 3 characters should consist of R and L.");

        public static SeatInfo Parse(string s)
        {
            if (s is null || s.Length != 10)
            {
                throw ParseFormatException;
            }
            (int row, int column) = (0, 0);

            for (int i = 0; i < 7; i++)
            {
                if (s[i] == 'B')
                {
                    row |= 1 << (6 - i);
                }
                else if (s[i] != 'F')
                {
                    throw ParseFormatException;
                }
            }
            for (int i = 7; i < 10; i++)
            {
                if (s[i] == 'R')
                {
                    column |= 1 << (9 - i);
                }
                else if (s[i] != 'L')
                {
                    throw ParseFormatException;
                }
            }

            return new SeatInfo(row, column);
        }
    }
}
