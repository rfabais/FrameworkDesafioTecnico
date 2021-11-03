using DesafioTecnicoFramework.Interfaces;
using System;

namespace DesafioTecnicoFramework
{
    public class ConsoleHelper : IConsoleHelper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public void Write()
        {
            Console.WriteLine();
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}
