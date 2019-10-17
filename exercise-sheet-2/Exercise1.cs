using System;
using System.IO;

namespace exercise_sheet_2
{
    public class Exercise1
    {
        private int[] stack;
        public Exercise1()
        {
            this.stack = new int[32];

            string[] rawApplication = this.LoadFile("aufgabe1.rm");
            this.InterpretRawFile(rawApplication);
            this.PrintStack();
        }

        private string[] LoadFile(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(currentDirectory, fileName);
            string[] rawApplication = System.IO.File.ReadAllLines(filePath);

            return rawApplication;
        }

        private void InterpretRawFile(string[] rawApplication)
        {
            bool halt = false;

            foreach (string command in rawApplication)
            {
                if(!command.StartsWith('#') && !command.Equals("") && !halt)
                {
                    string[] commandParts = command.Split(' ', 2);
                    int operand = Int32.Parse(commandParts[1]);

                    switch(commandParts[0])
                    {
                        default:
                            break;
                        case "INP":
                            Console.Write("Geben Sie bitte eine Zahl ein: ");
                            this.stack[operand] = Int32.Parse(Console.ReadLine());
                            break;
                        case "ADD":
                            this.stack[0] += this.stack[operand];
                            break;
                        case "MUL":
                            this.stack[0] *= this.stack[operand];
                            break;
                        case "DIV":
                            this.stack[0] /= this.stack[operand];
                            break;
                        case "LDA":
                            this.stack[0] = this.stack[operand];
                            break;
                        case "LDK":
                            this.stack[0] = operand;
                            break;
                        case "STA":
                            this.stack[operand] = this.stack[0];
                            break;
                        case "OUT":
                            Console.WriteLine("Adresse " + operand + ": " + this.stack[operand]);
                            break;
                        case "HLT":
                            if(operand == 99)
                                halt = true;
                            break;
                    }
                }
            }
        }

        private void PrintStack()
        {
            int i = 0;

            Console.Write(" - (" + this.stack[i] + ") - ");

            for(i = 1; i < this.stack.Length; i++) {
                if((i % 16) == 0)
                    Console.Write("\n - " + this.stack[i]);
                else
                    Console.Write(this.stack[i] + " - ");
            }
        }
    }
}