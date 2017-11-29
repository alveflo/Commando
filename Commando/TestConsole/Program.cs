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
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("1. Tables\n\n".Cyan().Bold());


            var t = new TablePrinter("Country", "Capital", "Population");
            t.AddRow("Sweden", "Stockholm", "~1,3M");
            t.AddRow("Norway", "Oslo", "~900k");
            t.AddRow("Finland", "Helsinki", "~600k");
            t.AddRow("Denmark", "Copenhagen", "~1,3M");
            t.Print();

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\n\n2. Pretty print\n\n".Cyan().Bold());


            var p = new PrettyPrinter();
            p.Add("Sweden", "Stockholm");
            p.Add("Norway", "Oslo");
            p.Add("Finland", "Helsinki");
            p.Add("Denmark", "Copenhagen");
            p.Print();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\n\n3. Prompts\n\n".Cyan().Bold());

            var prompt = new SelectPrompt("Choose country");
            prompt.Add(new PromptItem("Sweden", "SE"));
            prompt.Add(new PromptItem("Norway", "NO"));
            prompt.Add(new PromptItem("Finland", "FI"));
            prompt.Add(new PromptItem("Denmark", "DK"));
            var item = prompt.Prompt();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine($"You choosed {item.Name}: {item.Value.ToString()}");
            new YesNoQuestion("Is this correct?").Prompt();

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            var multiprompt = new MultiSelectPrompt("Choose countries");
            multiprompt.Add(new PromptItem("Sweden", "SE"));
            multiprompt.Add(new PromptItem("Norway", "NO"));
            multiprompt.Add(new PromptItem("Finland", "FI"));
            multiprompt.Add(new PromptItem("Denmark", "DK"));
            var answer = multiprompt.Prompt();

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            var username = new Question("Username", QuestionType.Text).Prompt();
            var password = new Question("Password", QuestionType.Password).Prompt();


            Console.WriteLine("You choosed:");
            foreach (var a in answer)
            {
                Console.WriteLine(a.Name);
            }

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
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

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\n\nt. Font styles\n\n".Cyan().Bold());
            p = new PrettyPrinter();
            p.Add("Zebra", "Zebra".Zebra());
            p.Add("Rainbow", "Rainbow".Rainbow());
            p.Add("Bold", "Bold".Bold());
            p.Add("Italic", "Italic".Italic());
            p.Add("Underline", "Underline".Underline());
            p.Add("Inverse", "Inverse".Inverse());
            p.Add("Red", "Red".Red());            
            p.Add("White", "White".White());
            p.Add("Grey", "Grey".Grey());
            p.Add("Black", "Black".Black());
            p.Add("Blue", "Blue".Blue());
            p.Add("Cyan", "Cyan".Cyan());
            p.Add("Green", "Green".Green());
            p.Add("Magenta", "Magenta".Magenta());
            p.Add("Red", "Red".Red());
            p.Add("Yellow", "Yellow".Yellow());
             
            p.Print();


            new YesNoQuestion("Quit?").Prompt();
        }
    }
}
