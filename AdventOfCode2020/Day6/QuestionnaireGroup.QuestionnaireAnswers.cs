using System;

namespace AdventOfCode2020
{
    public readonly partial struct QuestionnaireGroup
    {
        [Flags]
        public enum QuestionnaireAnswers : int
        {
            None = 0,
            A = 1 << 0,
            B = 1 << 1,
            C = 1 << 2,
            D = 1 << 3,
            E = 1 << 4,
            F = 1 << 5,
            G = 1 << 6,
            H = 1 << 7,
            I = 1 << 8,
            J = 1 << 9,
            K = 1 << 10,
            L = 1 << 11,
            M = 1 << 12,
            N = 1 << 13,
            O = 1 << 14,
            P = 1 << 15,
            Q = 1 << 16,
            R = 1 << 17,
            S = 1 << 18,
            T = 1 << 19,
            U = 1 << 20,
            V = 1 << 21,
            W = 1 << 22,
            X = 1 << 23,
            Y = 1 << 24,
            Z = 1 << 25
        }
    }
    public static class QuestionnaireAnswersExtensions
    {
        public static bool HasLetter(
            this QuestionnaireGroup.QuestionnaireAnswers source, char letter)
            => ((int)source & (1 << (letter - 'a'))) != 0;

        public static int AnsweredQuestionCount(this QuestionnaireGroup.QuestionnaireAnswers source)
        {
            const int QuestionCount = 26;
            int result = 0;

            for (int i = 0; i < QuestionCount; i++)
            {
                result += ((int)source >> i) & 1;
            }
            return result;
        }
    }
}
