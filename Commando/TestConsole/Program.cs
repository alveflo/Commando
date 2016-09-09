using System;
using System.Threading;

using Commando.Colors;
using Commando.Colors.Textwriter;
using Commando.Pretty;
using Commando.Progress;
using Commando.Table;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandoTextWriter.Use();

            Console.WriteLine("\n\nDemo of Commando!\n\n".Magenta().Bold());

            Console.WriteLine("1. Tables\n\n".Cyan().Bold());


            var t = new TablePrinter("Country", "Capital", "Population");
            t.AddRow("Sweden", "Stockholm", "~1,3M");
            t.AddRow("Norway", "Oslo", "~900k");
            t.AddRow("Finland", "Helsinki", "~600k");
            t.AddRow("Denmark", "Copenhagen", "~1,3M");
            t.Print();

            Console.WriteLine("\n\n2. Pretty print\n\n".Cyan().Bold());


            var p = new PrettyPrinter();
            p.Add(new PrettyItem("Sweden", "Stockholm"));
            p.Add(new PrettyItem("Norway", "Oslo"));
            p.Add(new PrettyItem("Finland", "Helsinki"));
            p.Add(new PrettyItem("Denmark", "Copenhagen"));
            p.Print();

            Console.WriteLine("\n\n2. Progress bar\n\n".Cyan().Bold());
            ProgressBar progressBar = new ProgressBar();
            progressBar.Increase(10, "Initializing");
            Thread.Sleep(2000);
            progressBar.Increase(10, "Downloading...");
            Thread.Sleep(1000);
            progressBar.Increase(10);
            Thread.Sleep(100);
            progressBar.Increase(10);
            Thread.Sleep(1000);
            progressBar.Increase(10, "Building");
            Thread.Sleep(100);
            progressBar.Increase(10);
            Thread.Sleep(100);
            progressBar.Increase(10);
            Thread.Sleep(1000);
            progressBar.Increase(10, "Creating databases");
            Thread.Sleep(1000);
            progressBar.Increase(10, "Finishing");
            Thread.Sleep(2000);
            progressBar.Increase(10);
        }
    }
}
