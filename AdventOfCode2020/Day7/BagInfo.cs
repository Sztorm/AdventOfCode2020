using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public readonly struct BagInfo : IEquatable<BagInfo>
    {
        private static readonly Regex BagInfoRegex = new Regex(
            @"([a-z]+ [a-z]+) bags contain (no other bags)?(\d+ ([a-z]+ ){2}bags?,? ?)*\.");
        private static readonly Regex BagInfoContentsRegex = new Regex(
            @"(\d+) ([a-z]+ [a-z]+) bags?,? ?");

        public readonly string Name;
        public readonly int Count;
        public readonly BagInfo[] Contents;

        public BagInfo(string name, int count, BagInfo[] contents)
        {
            Name = name;
            Count = count;
            Contents = contents;
        }

        public static BagInfo Parse(string s)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            Match inputValidityMatch = BagInfoRegex.Match(s);

            if (!inputValidityMatch.Success)
            {
                throw new FormatException(@"The provided string has wrong format. The pattern is: " +
                    @"""([a-z]+ [a-z]+) bags contain (no other bags)?(\d+ ([a-z]+ ){2}bags?,? ?)*\.""");
            }
            const int BagsContainLength = 14;
            string name = inputValidityMatch.Groups[1].Value;
            int sliceStartIndex = name.Length + BagsContainLength;
            int sliceLength = s.Length - (sliceStartIndex);
            ReadOnlySpan<char> inputSlice = s.AsSpan(sliceStartIndex, sliceLength);

            if (inputSlice.SequenceCompareTo("no other bags.".AsSpan()) == 0)
            {
                return new BagInfo(name, 1, Array.Empty<BagInfo>());
            }
            var contents = new BagInfo[inputSlice.GetOccurenceCount(',') + 1];
            Match loopedMatch = BagInfoContentsRegex.Match(s, sliceStartIndex, sliceLength);
            int contentIndex = 0;

            while (loopedMatch.Success)
            {
                GroupCollection loopedGroups = loopedMatch.Groups;
                contents[contentIndex] = new BagInfo(loopedGroups[2].Value, int.Parse(loopedGroups[1].Value), Array.Empty<BagInfo>());
                int matchValueLength = loopedMatch.Value.Length;

                sliceStartIndex += matchValueLength;
                sliceLength -= matchValueLength;
                contentIndex++;
                loopedMatch = BagInfoContentsRegex.Match(s, sliceStartIndex, sliceLength);
            }
            return new BagInfo(name, 1, contents);
        }

        public override int GetHashCode() => Name.GetHashCode();

        public bool Equals(BagInfo other)
        {
            if (other.GetHashCode() != GetHashCode())
            {
                return false;
            }
            return Name == other.Name;// && Count == other.Count;
        }

        public override bool Equals(object? obj) => obj is BagInfo bag && Equals(bag);

        public static bool operator ==(BagInfo left, BagInfo right) => left.Equals(right);

        public static bool operator !=(BagInfo left, BagInfo right) => !left.Equals(right);
    }
}
