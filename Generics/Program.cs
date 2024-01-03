using Generics.UserInteraction;

GenericsConsoleApp genericsConsoleApp = new();

try
{
    genericsConsoleApp.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Exception Caught : " + ex.Message);
}

List<int> integers = new() { 10, 2, 43, -54, 56, 4, 100 };
List<int> integers2 = new() { 10, 2, 4, -5, 5, 4, 10 };

// Func<int, bool> predicate1 = IsEven;
// Func<int, bool> predicate2 = IsGreaterThan10;

// Console.WriteLine(IsAny(integers, predicate1));
// Console.WriteLine(IsAny(integers2, predicate2));

// Lambdas
Console.WriteLine(IsAny(integers, n => n % 2 == 0));
Console.WriteLine(IsAny(integers2, n => n > 10));
Console.WriteLine();

// Delegates
ProcessingString processingString1 = TrimTo5Letters;
ProcessingString processingString2 = ToUpper;

Console.WriteLine(processingString1("Helloooooo"));
Console.WriteLine(processingString2("Helloooooo"));

Print print1 = text => Console.WriteLine(text.ToUpper());
Print print2 = text => Console.WriteLine(text.ToLower());
Print multicast = print1 + print2;
multicast("Phoenix A Star");
Console.WriteLine();

// Dictionary
WorkingWIthDictionary.DictionaryWork();
WorkingWithEmployee workingWithEmployee = new();
workingWithEmployee.DisplayAverageSalariesPerDepartment();

// Number Filter
Console.WriteLine($"{Environment.NewLine}Number Filter{Environment.NewLine}");

List<int> integers3 = new(10);
DisplayListOfNumbers displayListOfNumbers = new();

SetRandomNumbers.Set(integers3, -10, 10);
displayListOfNumbers.Display(integers3);

FilteringStrategySelector<int> filteringStrategySelector = new();

string? userInput;
do
{
    Console.WriteLine($"{Environment.NewLine}Select Fileter:-");
    Console.WriteLine(string.Join(Environment.NewLine,
        filteringStrategySelector.FilteringStrategiesNames));
    userInput = Console.ReadLine();
}
while (string.IsNullOrEmpty(userInput));

var filteringStrategy = new FilteringStrategySelector<int>().Select(userInput);
var result = Filter.FilterBy(filteringStrategy, integers3);
displayListOfNumbers.Display(result);

string[] words = new[] { "Buy", "Aero", "Airplane", "Tom" };
var aWords = Filter.FilterBy(word => word.StartsWith('a'), words);
foreach (var word in aWords)
{
    Console.WriteLine(word);
}

Console.WriteLine($"{Environment.NewLine}Press any key to exit....");
Console.ReadKey();

/* bool IsEven(int arg)
{
    return arg % 2 == 0;
}

bool IsGreaterThan10(int arg)
{
    return arg > 10;
} */

/* bool isAnyNumberLargerThan10(IEnumerable<int> ints)
{
    foreach (var item in ints)
    {
        if (item > 10)
        {
            return true;
        }
    }
    return false;
} */

// Func
bool IsAny(IEnumerable<int> ints, Func<int, bool> predicate)
{
    foreach (var item in ints)
    {
        if (predicate(item))
        {
            return true;
        }
    }
    return false;
}

// Delegates
string TrimTo5Letters(string input)
{
    return input.Substring(0, 5);
}

string ToUpper(string input)
{
    return input.ToUpper();
}

delegate string ProcessingString(string input);
delegate void Print(string input);