using System;
using Commando.Colors;
using Commando.Figures;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var Printer = new Printer();
            Printer.Red("? ").Blue("What is your favorite dish: ").NewLine().Green("This was cool!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine();
            Console.WriteLine(Figure.Circle);
            Console.WriteLine(Figure.CircleDotted);
            Console.WriteLine(Figure.CircleFilled);
            Console.WriteLine(Figure.ArrowDown);
            Console.WriteLine(Figure.ArrowUp);
            Console.WriteLine(Figure.ArrowLeft);
            Console.WriteLine(Figure.ArrowRight);
            Console.WriteLine(Figure.Hamburger);
            Console.WriteLine(Figure.Pointer);
            Console.WriteLine(Figure.PointerSmall);
            Console.WriteLine(Figure.Smiley);
            Console.WriteLine(Figure.Heart);

            Console.ReadLine();
        }
    }
}
