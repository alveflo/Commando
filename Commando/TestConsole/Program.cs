using System;
using Commando.Colors;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var Printer = new Printer();
            Printer.Red("? ").Blue("What is your favorite dish: ").NewLine().Green("This was cool!");


            Console.ReadLine();
        }
    }
}
