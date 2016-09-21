using System;

using Commando.Colors;

namespace Commando.Prompt
{
    public class Question
    {
        private string Message { get; set; }

        public Question(string question)
        {
            Message = question;
        }

        public string Prompt()
        {
            Console.WriteLine("? ".Cyan().Bold() + Message.White().Bold());
            Console.Write("> ".Cyan().Bold());
            return Console.ReadLine();
        }
    }
}