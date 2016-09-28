# Commando
C# library for creating command line user interfaces.
# Install
```
PM> Install-Package Commando.UI
```
# Table of content
* [Features](#features)
  * [Printing](#Printing)
    * [Table print](#table-print)
    * [Pretty print](#pretty-print)
  * [Select lists](#select-lists)
    * [Select list](#single-select-list)
    * [Multi select](#multi-selectcheckbox-list)
  * [Prompts](#prompts)
    * [Question prompt](#question-prompt)
    * [Yes/No prompt](#yesno-prompt)

# Features
## Printing
### Table print
```csharp
var table = new TablePrinter("Country", "Capital", "Population");
table.AddRow("Sweden", "Stockholm", "~1,3M");
table.AddRow("Norway", "Oslo", "~900k");
table.AddRow("Finland", "Helsinki", "~600k");
table.AddRow("Denmark", "Copenhagen", "~1,3M");
table.Print();
```
Prints:
![Table](https://raw.githubusercontent.com/alveflo/Commando/master/Commando/img/Tables.PNG)
### Pretty print
```csharp
var pretty = new PrettyPrinter();
pretty.Add("Sweden", "Stockholm");
pretty.Add("Norway", "Oslo");
pretty.Add("Finland", "Helsinki");
pretty.Add("Denmark", "Copenhagen");
pretty.Print();
```
Prints:
![Pretty](https://raw.githubusercontent.com/alveflo/Commando/master/Commando/img/Pretty.PNG)
## Select lists
### Single select list
```csharp
var prompt = new SelectPrompt("Choose country");
prompt.Add(new PromptItem("Sweden", "SE"));
prompt.Add(new PromptItem("Norway", "NO"));
prompt.Add(new PromptItem("Finland", "FI"));
prompt.Add(new PromptItem("Denmark", "DK"));
var item = prompt.Prompt();
```
Prints:
![Select prompt](https://raw.githubusercontent.com/alveflo/Commando/master/Commando/img/SelectPrompt.PNG)
### Multi select/checkbox list
```csharp
var multiprompt = new MultiSelectPrompt("Choose countries");
multiprompt.Add(new PromptItem("Sweden", "SE"));
multiprompt.Add(new PromptItem("Norway", "NO"));
multiprompt.Add(new PromptItem("Finland", "FI"));
multiprompt.Add(new PromptItem("Denmark", "DK"));
var answer = multiprompt.Prompt();
```
Prints:
![Multi select](https://raw.githubusercontent.com/alveflo/Commando/master/Commando/img/MultiselectPrompt.PNG)
## Prompts
### Question prompt
```csharp
var password = new Question("Enter password", QuestionType.Password).Prompt();
```
Prints:
![Question prompt](https://raw.githubusercontent.com/alveflo/Commando/master/Commando/img/Password.PNG)
### Yes/No prompt
```csharp
Console.WriteLine($"You choosed Sweden: SE");
var answer = new YesNoQuestion("Is this correct?").Prompt();
```
Prints:
![Yes/No prompt](https://raw.githubusercontent.com/alveflo/Commando/master/Commando/img/Accept.PNG)
