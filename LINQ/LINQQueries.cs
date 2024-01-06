
using Linq.UserInteraction;

public class LINQQueries : ILINQQueries
{
    private readonly IDisplay _display;
    private readonly IDisplayCollection _displayCollection;

    private readonly string newLine = Environment.NewLine;
    private readonly string separator = ", ";
    private readonly Random rand = new();
    private const int MIN = -100, MAX = 101;

    public LINQQueries(IDisplay display, IDisplayCollection displayCollection)
    {
        _display = display;
        _displayCollection = displayCollection;
    }

    public void AnyAndAll()
    {
        _display.Display($"{newLine}Any & All Methods:-");

        var words = new string[] { "quick", "Brown", "FOX", };
        var words2 = new string[] { "quick", "Brown", "fox" };

        // Console.WriteLine(words.Any(word => word.All(letter => char.IsUpper(letter))));
        // Console.WriteLine(words2.Any(word => word.All(letter => char.IsUpper(letter))));
        _display.Display(IsAnyLetterUpperCase(words).ToString());
        _display.Display(IsAnyLetterUpperCase(words2).ToString());
    }

    private bool IsAnyLetterUpperCase(IEnumerable<string> words)
        => words.Any(word => word.All(letter => char.IsUpper(letter)));

    public void WhereMethod()
    {
        _display.Display($"{newLine}Where Method:-");

        List<int> integers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var oddNumbers = integers.Where(number => number % 2 != 0);

        _displayCollection.Display(integers, separator);
        _displayCollection.Display(oddNumbers, separator);

        List<string> words = new() { "stars", "planets", "space", "time", "string" };
        Console.WriteLine(string.Join(", ", words));

        var wordsLongerThan5Letters = words.Where(word => word.Length > 5);
        Console.WriteLine(string.Join(", ", wordsLongerThan5Letters));

        var shortWords = words.Where(word => word.Length < 3);
    }

    public void WhereAndOrderBy()
    {
        _display.Display($"{newLine}Where & OrderBy Methods:-");

        int[] nums = Enumerable.Range(0, 10).
            Select(i => rand.Next(MIN, MAX)).ToArray();
        _displayCollection.Display(nums, separator);

        List<int> integers = Enumerable.Range(0, 12).
            Select(i => rand.Next(MIN, MAX)).ToList();
        _displayCollection.Display(integers, separator);

        var orderEvenNumbers = integers.Where(number => number % 2 == 0).
            OrderBy(number => number);
        _displayCollection.Display(orderEvenNumbers, separator);

        List<double> floatingPoints = Enumerable.Range(0, 10).
            Select(i => rand.NextDouble() * (MAX - MIN) + MIN).ToList();
        _displayCollection.Display(floatingPoints, separator);

        // Order Method
        var orderFloatingPoints = floatingPoints.Order();
        _displayCollection.Display(orderFloatingPoints, separator);
        // var orderedFloatingPointsDescending = floatingPoints.OrderDescending();
        // _displayCollection.Display(orderedFloatingPointsDescending, separator);
    }

    public void CountMethod()
    {
        _display.Display($"{newLine}Count Method:-");

        var integers = Enumerable.Range(0, 10).
            Select(i => rand.Next(MIN, MAX)).ToArray();
        _displayCollection.Display(integers, separator);

        var countOfIntegersGreaterThan10 = integers.Count(num => num > 10);
        _display.Display(countOfIntegersGreaterThan10.ToString());
    }

    public void ContainsMethod()
    {
        _display.Display($"{newLine}Contains Method:-");

        List<double> floatingPoints = new() { 1.12, 7.5365, 10.23534, -896.46, 0.12345 };
        bool is0_12345Present = floatingPoints.Contains(0.12345);
        bool isNegative896_46Present = floatingPoints.Contains(-896.46);
        bool isNegative896_45Present = floatingPoints.Contains(-896.45);

        _display.Display(is0_12345Present.ToString());
        _display.Display(isNegative896_46Present.ToString());
        _display.Display(isNegative896_45Present.ToString());
    }

    public void FirstAndLastMethods()
    {
        _display.Display($"{newLine}First and Last Methods:-");

        List<int> integers = Enumerable.Range(0, 5).
            Select(num => rand.Next(MIN, MAX)).ToList();
        _displayCollection.Display(integers, separator);

        var firstOddNumber = integers.FirstOrDefault(number => number % 2 != 0);
        _display.Display(firstOddNumber.ToString());

        var lastNumber = integers.LastOrDefault();
        _display.Display(lastNumber.ToString());

        var largestNumber = integers.Order().Last();
        _display.Display(largestNumber.ToString());
    }

    public void DistinctMethod()
    {
        _display.Display($"{newLine}Distinct Method:-");

        List<int> integers = new() { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        _displayCollection.Display(integers, separator);

        var noDuplicates = integers.Distinct();
        _displayCollection.Display(noDuplicates, separator);
    }

    public void SelectMethod()
    {
        _display.Display($"{newLine}Select Method:-");

        List<int> integers = Enumerable.Range(0, 10)
            .Select(number => rand.Next(MIN, MAX)).ToList();
        _displayCollection.Display(integers, separator);

        var doubled = integers.Select(number => number * 2);
        _displayCollection.Display(doubled, separator);
    }

    /* private bool IsAnyWordUpperCase(IEnumerable<string> words)
    {
        foreach (var word in words)
        {
            bool areAllLettersUpperCase = true;
            foreach (var letter in word)
            {
                if (char.IsLower(letter))
                {
                    areAllLettersUpperCase = false;
                }
            }
            if (areAllLettersUpperCase)
            {
                return true;
            }
        }
        return false;
    } */
}