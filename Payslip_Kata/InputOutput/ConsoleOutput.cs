using System;
using System.Threading.Channels;

namespace Payslip_Kata.InputOutput
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}