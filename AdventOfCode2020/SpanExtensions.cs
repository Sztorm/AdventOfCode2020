﻿using System;

namespace AdventOfCode2020
{
    public static class SpanExtensions
    {
        public static long Sum(this Span<int> source)
        {
            long result = 0;

            for (int i = 0, length = source.Length; i < length; i++)
            {
                result += source[i];
            }
            return result;
        }

        public static long Product(this Span<int> source)
        {
            long result = 1;

            for (int i = 0, length = source.Length; i < length; i++)
            {
                result *= source[i];
            }
            return result;
        }

        public static int GetOccurenceCount<T>(this ReadOnlySpan<T> collection, T value)
            where T : IEquatable<T>
        {
            int result = 0;

            for (int i = 0, length = collection.Length; i < length; i++)
            {
                if (collection[i].Equals(value))
                {
                    result++;
                }
            }
            return result;
        }
    }
}
