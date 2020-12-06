using System;

namespace AdventOfCode2020
{
    public readonly partial struct QuestionnaireGroup
    {
        private readonly QuestionnaireAnswers[] AnswersArray;

        public int Count => AnswersArray.Length;

        public QuestionnaireAnswers AnyCommonAnswers
        {
            get
            {
                QuestionnaireAnswers result = QuestionnaireAnswers.None;

                for (int i = 0, length = AnswersArray.Length; i < length; i++)
                {
                    result |= AnswersArray[i];
                }
                return result;
            }
        }

        public QuestionnaireAnswers AllCommonAnswers
        {
            get
            {
                if (Count == 0)
                {
                    return QuestionnaireAnswers.None;
                }
                QuestionnaireAnswers result = AnswersArray[0];

                for (int i = 1, length = AnswersArray.Length; i < length; i++)
                {
                    result &= AnswersArray[i];
                }
                return result;
            }
        }

        public QuestionnaireGroup(QuestionnaireAnswers[] answersArray)
            => AnswersArray = answersArray;

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
            var resultAnswers = new QuestionnaireAnswers[answersLenght];

            for (int i = 0; i < answersLenght; i++)
            {
                if (answers[i].Length == 0)
                {
                    throw ParseFormatException;
                }
                resultAnswers[i] = ParseAnswers(answers[i]);
            }
            return new QuestionnaireGroup(resultAnswers);
        }
    }
}
