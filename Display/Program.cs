
using Display.DisplayOnConsole.cs;
using Display.People;
using Display.UserInteraction;

IDisplay display = new DisplayOnConsole();
DisplayConsoleApp displayConsoleApp = new(
    new DisplayOnConsole()
);

try
{
    displayConsoleApp.Run();
}
catch (Exception ex)
{
    display.Display($"{Environment.NewLine}Exception caught : {ex.Message}");
}

display.Display($"{Environment.NewLine}Press any key to exit....");
Console.ReadKey();

class DisplayConsoleApp
{
    private readonly IDisplay _display;

    public DisplayConsoleApp(IDisplay display)
    {
        _display = display;
    }

    public void Run()
    {
        _display.Display("This is a message. ");
        _display.DisplayLine("This is another message");

        WorkingWithNumbers workingWithNumbers = new();

        _display.DisplayLine($"{Environment.NewLine}Collection of random integers:-");
        workingWithNumbers.Integers();

        _display.DisplayLine($"{Environment.NewLine}Collection of random floating-points:-");
        workingWithNumbers.FloatingPoints();

        WorkingWithDictionary workingWithDictionary = new();

        _display.DisplayLine($"{Environment.NewLine}Dictionary:-");
        workingWithDictionary.Work();

        WorkingWithLookup workingWithLookup = new();

        _display.DisplayLine($"{Environment.NewLine}Lookup:-");
        workingWithLookup.Work();
    }
}

public class WorkingWithDictionary
{
    public void Work()
    {
        Dictionary<string, string> countriesContinent = new()
        {
            {"New Zealand", "Australia"},
            {"India", "Asia"},
            {"Germany", "Europe"},
            {"South Africa", "Africa"},
            {"USA", "North America"},
            {"Chile", "South America"},
        };
        DisplayDictionaryElementsOnConsole.Display(countriesContinent);
    }
}

public class WorkingWithLookup
{
    public void Work()
    {
        List<IStudent> students = new()
        {
            new Student("John", "Atkinson", 12, 1001, 9.0F),
            new Student("Jack", "Stuarts", 12, 1002, 7.0F),
            new Student("Brett", "Parker", 12, 1003, 8.0F),
            new Student("Samantha", "Potts", 12, 1004, 9.0F),
        };

        var studentsLookup = students.ToLookup(student => student.FirstName,
            student => student.Grade);
        DisplayLookupElementsOnConsole.Display(studentsLookup);
    }
}