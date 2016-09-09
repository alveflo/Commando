using System;
using System.Collections.Generic;

using Commando.Colors;

namespace Commando.Prompt
{
    public class SelectPrompt
    {
        public string Question { get; set; }
        public int SelectedIndex { get; set; }

        private List<PromptItem> PromptItems { get; set; } 
        public SelectPrompt(string question)
        {
            PromptItems = new List<PromptItem>();
            Question = question;
        }

        public void Add(PromptItem item)
        {
            PromptItems.Add(item);
        }

        public void Prompt()
        {
            Console.WriteLine("? ".Cyan().Bold() + Question.White().Bold() + " (Use arrow keys)".White());
            foreach (var item in PromptItems)
            {
                Console.WriteLine($"  {item.Name}".White());
            }
        }
    }
}