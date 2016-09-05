using System;

namespace Commando.Colors
{
    public class Printer
    {
        public Printer Black(string str) => Print(ConsoleColor.Black, str);
        public Printer DarkBlue(string str) => Print(ConsoleColor.DarkBlue, str);
        public Printer DarkGreen(string str) => Print(ConsoleColor.DarkGreen, str);
        public Printer DarkCyan(string str) => Print(ConsoleColor.DarkCyan, str);
        public Printer DarkRed(string str) => Print(ConsoleColor.DarkRed, str);
        public Printer DarkMagenta(string str) => Print(ConsoleColor.DarkMagenta, str);
        public Printer DarkYellow(string str) => Print(ConsoleColor.DarkYellow, str);
        public Printer Gray(string str) => Print(ConsoleColor.Gray, str);
        public Printer DarkGray(string str) => Print(ConsoleColor.DarkGray, str);
        public Printer Blue(string str) => Print(ConsoleColor.Blue, str);
        public Printer Green(string str) => Print(ConsoleColor.Green, str);
        public Printer Cyan(string str) => Print(ConsoleColor.Cyan, str);
        public Printer Red(string str) => Print(ConsoleColor.Red, str);
        public Printer Magenta(string str) => Print(ConsoleColor.Magenta, str);
        public Printer Yellow(string str) => Print(ConsoleColor.Yellow, str);
        public Printer White(string str) => Print(ConsoleColor.White, str);

        public Printer Print(ConsoleColor color, string str)
        {
            ConsoleColor currentConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ForegroundColor = currentConsoleColor;
            return this;
        }

        public Printer NewLine()
        {
            Console.WriteLine();
            return this;
        }
    }
}