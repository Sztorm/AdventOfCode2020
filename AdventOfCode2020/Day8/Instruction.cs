using System;

namespace AdventOfCode2020
{
    public readonly struct Instruction
    {
        private const string NopToken = "nop";
        private const string AccToken = "acc";
        private const string JmpToken = "jmp";

        public readonly InstructionType Type;
        public readonly int Argument;

        public Instruction(InstructionType type, int argument)
            => (Type, Argument) = (type, argument);

        private static bool IsDigit(char character) => character >= '0' && character <= '9';

        private static FormatException ParseFormatException => new (
            "The provided string has wrong format. The pattern is: " +
            @"""((nop)|(acc)|(jmp)) [\+-]\d+""");

        public static Instruction Parse(ReadOnlySpan<char> input)
        {
            int inputLength = input.Length;
            const int MinInstructionTextLength = 6;
            const int InstructionTokenLength = 3;

            if (inputLength < MinInstructionTextLength)
            {
                throw ParseFormatException;
            }
            InstructionType type = input.Slice(0, InstructionTokenLength) switch
            {
                ReadOnlySpan<char> s when s.SequenceCompareTo(NopToken) == 0 => InstructionType.NOP,
                ReadOnlySpan<char> s when s.SequenceCompareTo(AccToken) == 0 => InstructionType.ACC,
                ReadOnlySpan<char> s when s.SequenceCompareTo(JmpToken) == 0 => InstructionType.JMP,
                _ => throw ParseFormatException
            };
            int i = InstructionTokenLength;

            if (input[i] != ' ')
            {
                throw ParseFormatException;
            }
            i++;
            if (input[i] != '-' && input[i] != '+')
            {
                throw ParseFormatException;
            }
            i++;
            for (; i < inputLength; i++)
            {
                if (!IsDigit(input[i]))
                {
                    throw ParseFormatException;
                }
            }

            ReadOnlySpan<char> numberText = input.Slice(
                InstructionTokenLength + 1,inputLength - InstructionTokenLength - 1);
            int argumentValue = int.Parse(numberText);

            return new Instruction(type, argumentValue);
        }
    }
}
