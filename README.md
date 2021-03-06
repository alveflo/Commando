# Commando
C# library for creating command line user interfaces.
# Install
```
PM> Install-Package Commando.UI
```
# Table of content
* [Features](#features)
  * [Printing](#Printing)
    * [Font style](#font-style)
    * [Table print](#table-print)
    * [Pretty print](#pretty-print)
  * [Select lists](#select-lists)
    * [Select list](#single-select-list)
    * [Multi select](#multi-selectcheckbox-list)
  * [Prompts](#prompts)
    * [Question prompt](#question-prompt)
    * [Yes/No prompt](#yesno-prompt)
  * [Progress bar](#progress-bar)
# Setup
In order to use the color printing, you need to plug Commando into the console:
```csharp
static void Main(string[] args)
{
   CommandoTextWriter.Use();
}
```
# Features
## Printing
### Font style
#### Example
```csharp
CommandoTextWriter.Use();
"Red text".Red();
"Blue bold text".Blue().Bold();
```
#### Available styles
##### Colors
- `White`
- `Grey`
- `Black`
- `Blue`
- `Cyan`
- `Green`
- `Magenta`
- `Red`
- `Yellow`
- `Zebra`
- `Rainbow`

##### Font weight
- `Bold`
- `Italic`
- `Underline`
- `Inverse`

##### Other
- `Reset` - resets format

### Table print
```csharp
var table = new TablePrinter("Country", "Capital", "Population");
table.AddRow("Sweden", "Stockholm", "~1,3M");
table.AddRow("Norway", "Oslo", "~900k");
table.AddRow("Finland", "Helsinki", "~600k");
table.AddRow("Denmark", "Copenhagen", "~1,3M");
table.Print();
```

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

![Multi select](https://raw.githubusercontent.com/alveflo/Commando/master/Commando/img/MultiselectPrompt.PNG)
## Prompts
### Question prompts
Available prompt types is `Password` and `Text`.
```csharp
var username = new Question("Username", QuestionType.Text).Prompt();
var password = new Question("Password", QuestionType.Password).Prompt();
```

![Question prompt](https://raw.githubusercontent.com/alveflo/Commando/master/Commando/img/Password.PNG)
### Yes/No prompt
```csharp
Console.WriteLine($"You choosed Sweden: SE");
var answer = new YesNoQuestion("Is this correct?").Prompt();
```

![Yes/No prompt](https://raw.githubusercontent.com/alveflo/Commando/master/Commando/img/Accept.PNG)

## Progress bar
```csharp
ProgressBar progressBar = new ProgressBar();
progressBar.Set(10, "Initializing");
progressBar.Set(20, "Downloading...");
progressBar.Set(30);
progressBar.Set(40);
progressBar.Set(50, "Building");
progressBar.Set(60);
progressBar.Set(70);
progressBar.Set(80);
progressBar.Set(90, "Finishing");
progressBar.Set(100);
```

![Progressbar](https://raw.githubusercontent.com/alveflo/Commando/master/Commando/img/Progressbar.PNG)

# Contribution
 - Port to .NET Core 2.2 ([@domischenk](https://github.com/domischenk))


# License
MIT License

Copyright (c) 2016 Victor Alveflo

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
