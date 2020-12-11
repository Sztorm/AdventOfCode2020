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

        private void ToggleCorruptedInstruction(int index)
        {
            ref Instruction instruction = ref program[index];
            instruction = instruction.With(instruction.Type == InstructionType.NOP ?
                InstructionType.JMP : InstructionType.NOP);
        }

        private void ModifyCorruptedInstructions(ref int possibleCorruptedInstructionIndex)
        {
            if (possibleCorruptedInstructionIndex - 1 >= 0)
            {
                ToggleCorruptedInstruction(possibleCorruptedInstructionIndex - 1);
            }
            int instructionLength = program.Length;

            for (int i = possibleCorruptedInstructionIndex; i < instructionLength; i++)
            {
                ref Instruction instruction = ref program[i];

                if (instruction.Type == InstructionType.NOP || instruction.Type == InstructionType.JMP)
                {
                    possibleCorruptedInstructionIndex = i + 1;
                    ToggleCorruptedInstruction(i);
                    return;
                }
            }
        }

        public int RunAndFix(Instruction[] program)
        {
            int instructionLength = program.Length;
            this.program = program;
            result = 0;
            visitedIndices = new BitArray(instructionLength);
            instructionIndex = 0;
            int possibleCorruptedInstructionIndex = 0;

            while (instructionIndex < instructionLength) 
            {
                if (!TryExecuteNextInstruction())
                {
                    ModifyCorruptedInstructions(ref possibleCorruptedInstructionIndex);
                    visitedIndices.SetAll(false);
                    result = 0;
                    instructionIndex = 0;
                }
            }
            return result;
        }
    }
}
