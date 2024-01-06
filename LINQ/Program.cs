
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

try
{
    _LINQConsoleApp.Run();
}
catch (Exception ex)
{
    displayOnConsole.Display($"An Exception Occurred : {ex.Message}");
}

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
        _LINQQueries.CountMethod();
        _LINQQueries.ContainsMethod();
        _LINQQueries.FirstAndLastMethods();
        _LINQQueries.DistinctMethod();
        _LINQQueries.SelectMethod();
        OrederBy_();
        DeferredExecution();
        AverageAndAnonymousTypes();
    }

    private void OrederBy_()
    {
        _display.Display($"{newLine}Order By:-");

        List<Person> persons = new()
        {
            new Person("Josh", "Gates", 44),
            new Person("Bill", "Gates", 64),
            new Person("Andrew", "", 42),
            new Person("Sherlock", "Holmes", 40),
            new Person("John", "Watson", 40),
            new Person("Greg", "Watson", 42),
            new Person("Steve", "", 50),
        };

        _displayCollection.Display(persons, newLine);

        var personsOrderByFirstName = persons.OrderBy(person => person.FirstName);
        _displayCollection.Display(personsOrderByFirstName, newLine);

        // var personsOrderByDesecendingAge = persons.OrderBy(person => person.Age);
        // _displayCollection.Display(personsOrderByDesecendingAge, newLine);

        var personsOrderByLastNameThenByAge = persons.OrderBy(person => person.LastName)
            .ThenBy(person => person.Age);
        _displayCollection.Display(personsOrderByLastNameThenByAge, newLine);
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

    private void AverageAndAnonymousTypes()
    {
        _display.Display($"{newLine}Average and Anonymous Types:-");

        Random rand = new();
        const int MIN = -10, MAX = 11;

        List<List<int>> listOfIntegers = new()
        {
            Enumerable.Range(0,10).Select(number => rand.Next(MIN, MAX)).ToList(),
            Enumerable.Range(0,11).Select(number => rand.Next(MIN, MAX)).ToList(),
            Enumerable.Range(0,9).Select(number => rand.Next(MIN, MAX)).ToList(),
        };

        foreach (var list in listOfIntegers)
        {
            _displayCollection.Display(list, separator);
        }

        var result = listOfIntegers.Select(list => new
        {
            list.Count,
            Average = list.Average()
        }).Select(countAndAverage => $"Count is {countAndAverage.Count}" +
            $", Average is {countAndAverage.Average}");

        _displayCollection.Display(result, newLine);
    }
}
