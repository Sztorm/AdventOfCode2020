namespace AdventOfCode2020
{
    public static class InstructionParser
    {
        public static Instruction[] Parse(string[] instructions)
        {
            int instructionsLength = instructions.Length;
            var result = new Instruction[instructionsLength];

            for (int i = 0; i < instructionsLength; i++)
            {
                result[i] = Instruction.Parse(instructions[i]);
            }
            return result;
        }
    }
}
