using System.Collections;

namespace AdventOfCode2020
{
    public class ConsoleInstructionInterpreter
    {
        private Instruction[] program;
        private BitArray visitedIndices;
        private int instructionIndex;
        private int result;

        private void ExecuteACC(int argument) => result += argument;

        private void ExecuteJMP(int argument) => instructionIndex += argument;

        private bool TryExecuteNextInstruction()
        {   
            ref readonly Instruction instruction = ref program[instructionIndex];

            if (visitedIndices[instructionIndex])
            {
                return false;
            }
            visitedIndices[instructionIndex] = true;

            switch (instruction.Type)
            {
                case InstructionType.ACC:
                    ExecuteACC(instruction.Argument);      
                    instructionIndex++;
                    break;
                case InstructionType.JMP:
                    ExecuteJMP(instruction.Argument);
                    break;
                default:
                    instructionIndex++;
                    break;
            }
            return true;
        }

        public int Run(Instruction[] program)
        {
            int instructionLength = program.Length;
            this.program = program;
            this.result = 0;
            visitedIndices = new BitArray(instructionLength);
            instructionIndex = 0;

            while(instructionIndex < instructionLength && TryExecuteNextInstruction()) {}
            return result;
        }
    }
}
