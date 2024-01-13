
using Linq.People;
using Linq.UserInteraction;

DisplayOnConsole displayOnConsole = new();
DisplayCollectionOnConsole displayCollectionOnConsole = new();

Student student1 = new("Name", "Second Name", 11, 01, 5.5F);
Student student2 = new("Name", "Second Name", 10, 01, 5.0F);
Console.WriteLine(student1.Equals(student2));

List<int> integers = new() { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 7, 8, 9, 0, 0 };
HashSet<int> uniqueIntegers = integers.Prepend(-1).ToHashSet();
displayCollectionOnConsole.Display(uniqueIntegers, ", ");

// List<char> alphabets = new(52);
// alphabets.AddRange(Enumerable.Range('A', 26).Select(number => (char)number));
// alphabets.AddRange(Enumerable.Range('a', 26).Select(number => (char)number));

var alphabets = Enumerable.Range('A', 26)
    .Concat(Enumerable.Range('a', 26))
        .Select(number => (char)number);
displayCollectionOnConsole.Display(alphabets, ", ");

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

    public LINQConsoleApp(IDisplay display, IDisplayCollection displayCollection,
        ILINQQueries lINQQueries)
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
        _LINQQueries.SelectManyMethod();
        _LINQQueries.AggregateMethod();
        _LINQQueries.ConcatAndUnion();
        _LINQQueries.RepeatMethod();
        _LINQQueries.GroupBy();
        _LINQQueries.IntersectAndExcept();
        _LINQQueries.JoinMethod();
        _LINQQueries.SingleMethod();
        _LINQQueries.TakeMethod();
        _LINQQueries.SkipMethod();
        _LINQQueries.ZipMethod();
        OrederBy_();
        DeferredExecution();
        AverageAndAnonymousTypes();
        LookUp();
    }

    private void OrederBy_()
    {
        _display.Display($"{SpecialCharacters.NewLine}Order By:-");

        List<IPerson> persons = new()
        {
            new Person("Josh", "Gates", 44),
            new Person("Bill", "Gates", 64),
            new Person("Andrew", "", 42),
            new Person("Sherlock", "Holmes", 40),
            new Person("John", "Watson", 40),
            new Person("Greg", "Watson", 42),
            new Person("Steve", "", 50),
        };

        _displayCollection.Display(persons, SpecialCharacters.NewLine);

        var personsOrderByFirstName = persons.OrderBy(person => person.FirstName);
        _displayCollection.Display(personsOrderByFirstName, SpecialCharacters.NewLine);

        // var personsOrderByDesecendingAge = persons.OrderBy(person => person.Age);
        // _displayCollection.Display(personsOrderByDesecendingAge, SpecialCharacters.NewLine);

        var personsOrderByLastNameThenByAge = persons.OrderBy(person => person.LastName)
            .ThenBy(person => person.Age);
        _displayCollection.Display(personsOrderByLastNameThenByAge, SpecialCharacters.NewLine);
    }

    private void DeferredExecution()
    {
        _display.Display($"{SpecialCharacters.NewLine}Deferred Execution:-");

        var words = new List<string> { "aaaa", "bbb", "cc", "d" };
        var shortWords = words.Where(word => word.Length < 3).ToList();

        _display.Display("First Iteration:-");
        _displayCollection.Display(shortWords, SpecialCharacters.Separator);

        words.Add("e");
        _display.Display("Second Iteration:-");
        _displayCollection.Display(shortWords, SpecialCharacters.Separator);

        // Console.WriteLine(string.Join(", ", shortWords));

        var animals = new List<string> { "Duck", "Lion", "Dolphin", "Tiger" };

        var animalNamesBeginWithD = animals.Where(animal =>
        {
            _display.Display("Checking name of animal " + animal);
            return animal.StartsWith('D');
        });

        _displayCollection.Display(animalNamesBeginWithD, SpecialCharacters.Separator);
    }

    private void AverageAndAnonymousTypes()
    {
        _display.Display($"{SpecialCharacters.NewLine}Average and Anonymous Types:-");

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
            _displayCollection.Display(list, SpecialCharacters.Separator);
        }

        var result = listOfIntegers.Select(list => new
        {
            list.Count,
            Average = list.Average()
        }).Select(countAndAverage => $"Count is {countAndAverage.Count}" +
            $", Average is {countAndAverage.Average}");

        _displayCollection.Display(result, SpecialCharacters.NewLine);
    }

    private void LookUp()
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
        _displayCollection.Display(studentsLookup);
    }

}
