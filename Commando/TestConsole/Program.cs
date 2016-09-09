using System;
using System.Threading;

using Commando.Colors;
using Commando.Colors.Textwriter;
using Commando.Pretty;
using Commando.Progress;
using Commando.Prompt;
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

            Console.WriteLine("\n\n3. Prompts\n\n".Cyan().Bold());

            var prompt = new SelectPrompt("Choose country");
            prompt.Add(new PromptItem("Sweden", "SE"));
            prompt.Add(new PromptItem("Norway", "NO"));
            prompt.Add(new PromptItem("Finland", "FI"));
            prompt.Add(new PromptItem("Denmark", "DK"));
            prompt.Prompt();

            Console.WriteLine("\n\n4. Progress bar\n\n".Cyan().Bold());
            ProgressBar progressBar = new ProgressBar();
            progressBar.Set(10, "Initializing");
            Thread.Sleep(2000);
            progressBar.Set(20, "Downloading...");
            Thread.Sleep(1000);
            progressBar.Set(30);
            Thread.Sleep(100);
            progressBar.Set(40);
            Thread.Sleep(1000);
            progressBar.Set(50, "Building");
            Thread.Sleep(100);
            progressBar.Set(60);
            Thread.Sleep(100);
            progressBar.Set(70);
            Thread.Sleep(1000);
            progressBar.Set(80, "Creating databases");
            Thread.Sleep(1000);
            progressBar.Set(90, "Finishing");
            Thread.Sleep(2000);
            progressBar.Set(100);

        }
    }
}
