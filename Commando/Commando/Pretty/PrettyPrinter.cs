using System;
using System.Collections.Generic;

using Commando.Colors;

namespace Commando.Pretty
{
    public class PrettyPrinter
    {
        private List<PrettyItem> PrettyItems { get; set; }

        private int LongestName = 0;

        public PrettyPrinter()
        {
            PrettyItems = new List<PrettyItem>();
        }


        public void Add(string name, string value)
        {
            Add(new PrettyItem(name, value));
        }

        private void Add(PrettyItem item)
        {
            LongestName = (item.Name.Length > LongestName) ? item.Name.Length : LongestName;
            PrettyItems.Add(item);
        }

        public void Print()
        {
            LongestName = LongestName + 2;
            foreach (var item in PrettyItems)
            {
                Console.WriteLine(string.Format("{0, " + LongestName + "} : {1}", item.Name, item.Value.Yellow()));
            }
        }
    }
}