using System.IO;

namespace AdventOfCode2020
{
    class PuzzleIOManager
    {
        public static readonly string ProjectPath = Directory.GetParent(
            Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public static string[] ReadTextLines(string relativeInputPath)
            => File.ReadAllLines(Path.Combine(ProjectPath, relativeInputPath));

        public static void SaveTextLines(string relativeOutputPath, string[] textLines)
            => File.WriteAllLines(Path.Combine(ProjectPath, relativeOutputPath), textLines);
    }
}
