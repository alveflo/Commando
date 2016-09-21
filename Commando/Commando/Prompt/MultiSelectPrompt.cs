using System;
using System.Collections.Generic;
using System.Linq;

using Commando.Colors;

namespace Commando.Prompt
{
    sealed class SelectPromptItem
    {
        public PromptItem Item { get; set; }
        public bool Selected { get; set; }

        public SelectPromptItem(PromptItem item)
        {
            Item = item;
            Selected = false;
        }
    }

    public class MultiSelectPrompt
    {
        private string Question { get; set; }
        private int SelectedIndex { get; set; }
        private List<SelectPromptItem> PromptItems { get; set; }
        private void AddToList(PromptItem item) => PromptItems.Add(new SelectPromptItem(item));

        public MultiSelectPrompt(string question)
        {
            PromptItems = new List<SelectPromptItem>();
            Question = question;
        }

        public void Add(PromptItem item)
        {
            AddToList(item);
        }

        public IEnumerable<PromptItem> Prompt()
        {
            Console.WriteLine("? ".Cyan().Bold() + Question.White().Bold() + " (Use space to select/deselect)".White());

            var index = 0;
            Print(index, false);
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            while (!pressedKey.Key.Equals(ConsoleKey.Enter))
            {
                index = (pressedKey.Key.Equals(ConsoleKey.DownArrow)) ? index + 1 : index;
                index = (pressedKey.Key.Equals(ConsoleKey.UpArrow)) ? index - 1 : index;

                if (pressedKey.Key.Equals(ConsoleKey.Spacebar))
                {
                    PromptItems[index].Selected = !PromptItems[index].Selected;
                }

                if (index < 0) index = PromptItems.Count - 1;
                if (index >= PromptItems.Count) index = 0;

                Print(index, true);
                pressedKey = Console.ReadKey();
            }

            return PromptItems
                .Where(x => x.Selected)
                .Select(x => x.Item);
        }

        private void Print(int index, bool redraw)
        {
            if (redraw)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = Console.CursorTop - PromptItems.Count;
            }

            for (var i = 0; i < PromptItems.Count; i++)
            {
                var item = PromptItems[i];
                var str = (i == index) ? "> ".Yellow().Bold() : "  ";
                str += (item.Selected) ? $"[x] {item.Item.Name}".Cyan().Bold() : $"[ ] {item.Item.Name}".White();
                Console.WriteLine(str);

            }

        }

    }
}