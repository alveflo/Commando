using System;
using System.Collections.Generic;

using Commando.Colors;

namespace Commando.Prompt
{
    public class SelectPrompt
    {
        private string Question { get; set; }
        private int SelectedIndex { get; set; }
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

        public PromptItem Prompt()
        {
            Console.WriteLine("? ".Cyan().Bold() + Question.White().Bold() + " (Use arrow keys)".White());

            var index = 0;
            Print(index, false);
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            while (!pressedKey.Key.Equals(ConsoleKey.Enter))
            {
                index = (pressedKey.Key.Equals(ConsoleKey.DownArrow)) ? index + 1 : index;
                index = (pressedKey.Key.Equals(ConsoleKey.UpArrow)) ? index - 1 : index;

                if (index < 0) index = PromptItems.Count - 1;
                if (index >= PromptItems.Count) index = 0;

                Print(index, true);
                pressedKey = Console.ReadKey();
            }

            return PromptItems[index];
        }

        private void Print(int index, bool redraw)
        {
            //Console.SetCursorPosition(Console.);

            if (redraw)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = Console.CursorTop - PromptItems.Count;
            }

            for (var i = 0; i < PromptItems.Count; i++)
            {
                var item = PromptItems[i];
                var str = (i == index) ? $"> {item.Name}".Cyan().Bold() : $"  {item.Name}".White();
                Console.WriteLine(str);
            }
        }
    }
}