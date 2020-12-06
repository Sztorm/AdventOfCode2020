using System;

namespace AdventOfCode2020
{
    public readonly partial struct QuestionnaireGroup
    {
        public const int QuestionCount = 26;

        public readonly QuestionnaireAnswers Answers;
        public readonly int PeopleCount;

        public int AnsweredQuestionCount
        {
            get
            {
                int result = 0;

                for (int i = 0; i < QuestionCount; i++)
                {
                    result += ((int)Answers >> i) & 1;
                }
                return result;
            }
        }

        public QuestionnaireGroup(int peopleCount, QuestionnaireAnswers answers)
        {
            PeopleCount = peopleCount;
            Answers = answers;
        }

        private static bool IsSmallLetterInLatinAlphabet(char value)
            => value >= 'a' && value <= 'z';

        private static FormatException ParseAnswersFormatException => new(
            "The provided string has wrong format. The string length must be less than or equal " +
            "to 26. The string characters must be unique small latin alphabet letters.");

        private static FormatException ParseFormatException => new(
            "The provided strings must have length greater than zero. Each string in array must " +
            "not be empty and must follow Answer formatting rules.");

        public static QuestionnaireAnswers ParseAnswers(string s)
        {
            const int LatinAlphabetLength = 26;

            if (s is null || s.Length > LatinAlphabetLength)
            {
                throw ParseAnswersFormatException;
            }
            QuestionnaireAnswers result = QuestionnaireAnswers.None;

            for (int i = 0, length = s.Length; i < length; i++)
            {
                char letter = s[i];

                if (!IsSmallLetterInLatinAlphabet(letter))
                {
                    throw ParseAnswersFormatException;
                }
                if (result.HasLetter(letter))
                {
                    throw ParseAnswersFormatException;
                }
                result = (QuestionnaireAnswers)((int)result | (1 << (letter - 'a')));
            }
            return result;
        }

        public static QuestionnaireGroup Parse(ReadOnlySpan<string> answers)
        {
            int answersLenght = answers.Length;

            if (answersLenght == 0)
            {
                throw ParseFormatException;
            }
            QuestionnaireAnswers result = QuestionnaireAnswers.None;

            for (int i = 0; i < answersLenght; i++)
            {
                if (answers[i].Length == 0)
                {
                    throw ParseFormatException;
                }
                result |= ParseAnswers(answers[i]);
            }
            return new QuestionnaireGroup(answersLenght, result);
        }
    }
}
