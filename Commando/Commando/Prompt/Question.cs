using System;
using System.Security;

using Commando.Colors;

namespace Commando.Prompt
{
    public enum QuestionType
    {
        Text,
        Password
    }

    public class Question
    {
        private string Message { get; set; }
        private QuestionType Type { get; set; }

        public Question(string question, QuestionType questionType)
        {
            Message = question;
            Type = questionType;
        }

        public Question(string question) : this(question, QuestionType.Text) { }

        public string Prompt()
        {
            Console.WriteLine("? ".Cyan().Bold() + Message.White().Bold());
            Console.Write("> ".Cyan().Bold());

            return (Type.Equals(QuestionType.Password)) ? PromptPassword() : PromptText();
        }

        private string PromptPassword()
        {
            var pass = string.Empty;
            var key = Console.ReadKey(true);
            while (!key.Key.Equals(ConsoleKey.Enter))
            {
                if (key.Key != ConsoleKey.Backspace)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
                key = Console.ReadKey(true);
            }
            return pass;
        }

        private string PromptText()
        {
            return Console.ReadLine();
        }
    }
}