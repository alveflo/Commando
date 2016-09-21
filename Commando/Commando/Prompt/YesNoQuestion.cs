using System;
using System.IO.Pipes;

using Commando.Colors;

namespace Commando.Prompt
{
    public class YesNoQuestion
    {
        private string Message { get; set; }

        public YesNoQuestion(string question)
        {
            Message = question;
        }

        public bool Prompt()
        {
            Console.WriteLine("? ".Cyan().Bold() + Message.White().Bold());
            Console.Write("> [Y/N]".Cyan().Bold());
            var answer = Console.ReadLine() ?? "";
            if (answer.ToLower().Equals("y")) return true;
            return !answer.ToLower().Equals("n") && Prompt();
        }
    }
}