namespace Commando.Pretty
{
    public class PrettyItem
    {
        public PrettyItem(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; } 
        public string Value { get; set; }
    }
}