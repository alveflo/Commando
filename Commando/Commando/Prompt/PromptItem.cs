namespace Commando.Prompt
{
    public class PromptItem
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public PromptItem(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}