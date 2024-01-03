
using Linq.UserInteraction;

DisplayOnConsole displayOnConsole = new();
DisplayCollectionOnConsole displayCollectionOnConsole = new();

LINQConsoleApp _LINQConsoleApp = new(
    displayOnConsole,
    displayCollectionOnConsole,
    new LINQQueries(
        displayOnConsole,
        displayCollectionOnConsole
    )
);

_LINQConsoleApp.Run();

Console.WriteLine("Press any key to exit....");
Console.ReadKey();


class LINQConsoleApp
{
    private readonly IDisplay _display;
    private readonly IDisplayCollection _displayCollection;
    private readonly ILINQQueries _LINQQueries;
    private readonly string newLine = Environment.NewLine;
    private readonly string separator = ", ";

    public LINQConsoleApp(IDisplay display, IDisplayCollection displayCollection, ILINQQueries lINQQueries)
    {
        _display = display;
        _displayCollection = displayCollection;
        _LINQQueries = lINQQueries;
    }

    public void Run()
    {
        _LINQQueries.AnyAndAll();
        _LINQQueries.WhereMethod();
        _LINQQueries.WhereAndOrderBy();
        DeferredExecution();
    }

    private void DeferredExecution()
    {
        _display.Display($"{newLine}Deferred Execution:-");

        var words = new List<string> { "aaaa", "bbb", "cc", "d" };
        var shortWords = words.Where(word => word.Length < 3).ToList();

        _display.Display("First Iteration:-");
        _displayCollection.Display(shortWords, separator);

        words.Add("e");
        _display.Display("Second Iteration:-");
        _displayCollection.Display(shortWords, separator);

        // Console.WriteLine(string.Join(", ", shortWords));

        var animals = new List<string> { "Duck", "Lion", "Dolphin", "Tiger" };

        var animalNamesBeginWithD = animals.Where(animal =>
        {
            _display.Display("Checking name of animal " + animal);
            return animal.StartsWith('D');
        });

        _displayCollection.Display(animalNamesBeginWithD, separator);
    }
}
