using Linq.People;
using Linq.People.Department;
using Linq.UserInteraction;

public class LINQQueries : ILINQQueries
{
    private readonly IDisplay _display;
    private readonly IDisplayCollection _displayCollection;
    private readonly Random rand = new();
    private const int MIN = -100, MAX = 101;
    public LINQQueries(IDisplay display, IDisplayCollection displayCollection)
    {
        _display = display;
        _displayCollection = displayCollection;
    }

    public void AnyAndAll()
    {
        _display.Display($"{SpecialCharacters.NewLine}Any & All Methods:-");

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
        _display.Display($"{SpecialCharacters.NewLine}Where Method:-");

        List<int> integers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var oddNumbers = integers.Where(number => number % 2 != 0);

        _displayCollection.Display(integers, SpecialCharacters.Separator);
        _displayCollection.Display(oddNumbers, SpecialCharacters.Separator);

        List<string> words = new() { "stars", "planets", "space", "time", "string" };
        Console.WriteLine(string.Join(", ", words));

        var wordsLongerThan5Letters = words.Where(word => word.Length > 5);
        Console.WriteLine(string.Join(", ", wordsLongerThan5Letters));

        var shortWords = words.Where(word => word.Length < 3);
    }

    public void WhereAndOrderBy()
    {
        _display.Display($"{SpecialCharacters.NewLine}Where & OrderBy Methods:-");

        int[] nums = Enumerable.Range(0, 10).
            Select(i => rand.Next(MIN, MAX)).ToArray();
        _displayCollection.Display(nums, SpecialCharacters.Separator);

        List<int> integers = Enumerable.Range(0, 12).
            Select(i => rand.Next(MIN, MAX)).ToList();
        _displayCollection.Display(integers, SpecialCharacters.Separator);

        var orderEvenNumbers = integers.Where(number => number % 2 == 0).
            OrderBy(number => number);
        _displayCollection.Display(orderEvenNumbers, SpecialCharacters.Separator);

        List<double> floatingPoints = Enumerable.Range(0, 10).
            Select(i => rand.NextDouble() * (MAX - MIN) + MIN).ToList();
        _displayCollection.Display(floatingPoints, SpecialCharacters.Separator);

        // Order Method
        var orderFloatingPoints = floatingPoints.Order();
        _displayCollection.Display(orderFloatingPoints, SpecialCharacters.Separator);
        // var orderedFloatingPointsDescending = floatingPoints.OrderDescending();
        // _displayCollection.Display(orderedFloatingPointsDescending, SpecialCharacters.Separator);
    }

    public void CountMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Count Method:-");

        var integers = Enumerable.Range(0, 10).
            Select(i => rand.Next(MIN, MAX)).ToArray();
        _displayCollection.Display(integers, SpecialCharacters.Separator);

        var countOfIntegersGreaterThan10 = integers.Count(num => num > 10);
        _display.Display(countOfIntegersGreaterThan10.ToString());
    }

    public void ContainsMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Contains Method:-");

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
        _display.Display($"{SpecialCharacters.NewLine}First and Last Methods:-");

        List<int> integers = Enumerable.Range(0, 5).
            Select(num => rand.Next(MIN, MAX)).ToList();
        _displayCollection.Display(integers, SpecialCharacters.Separator);

        var firstOddNumber = integers.FirstOrDefault(number => number % 2 != 0);
        _display.Display(firstOddNumber.ToString());

        var lastNumber = integers.LastOrDefault();
        _display.Display(lastNumber.ToString());

        var largestNumber = integers.Order().Last();
        _display.Display(largestNumber.ToString());
    }

    public void DistinctMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Distinct Method:-");

        List<int> integers = new() { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        _displayCollection.Display(integers, SpecialCharacters.Separator);

        var noDuplicates = integers.Distinct();
        _displayCollection.Display(noDuplicates, SpecialCharacters.Separator);
    }

    public void SelectMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Select Method:-");

        List<int> integers = Enumerable.Range(0, 10)
            .Select(number => rand.Next(MIN, MAX)).ToList();
        _displayCollection.Display(integers, SpecialCharacters.Separator);

        var doubled = integers.Select(number => number * 2);
        _displayCollection.Display(doubled, SpecialCharacters.Separator);
    }

    public void SelectManyMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Select Many Method:-");

        List<List<int>> nestedListOfIntegers = new()
        {
            new List<int>{1, 2, 3},
            new List<int>{4, 5, 6},
            new List<int>{7, 8, 9}
        };

        var sum = nestedListOfIntegers.SelectMany(list => list).Sum();
        _display.Display($"Sum is {sum}");

        int[] naturalNumbers = Enumerable.Range(1, 3).ToArray();
        char[] alphabets = Enumerable.Range('A', 3).
            Select(number => (char)number).ToArray();

        var cartesianProduct = naturalNumbers.SelectMany(
            number => alphabets, (number, alphabet) => $"{number}, {alphabet}"
        );
        _displayCollection.Display(cartesianProduct, SpecialCharacters.NewLine);
    }

    public void AggregateMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Aggregate Method:-");

        // Random Numbers
        List<int> integers = Enumerable.Range(0, 5)
            .Select(number => rand.Next(MIN, MAX)).ToList();
        _displayCollection.Display(integers, SpecialCharacters.Separator);

        var sumOfIntegers = integers.Aggregate((sum, nextInt) => sum + nextInt);
        _display.Display($"Sum is {sumOfIntegers}");

        // The Sentence
        string sentence = "The quick brownish fox jumps over the lazy dog.";
        _display.Display(sentence);

        char[] delimiters = new char[] { ' ', '.' };

        var allLengths = sentence.Split(delimiters).
            Aggregate(Enumerable.Empty<int>(),
                (lenghtsCollection, nextWord)
                    => lenghtsCollection.Append(nextWord.Length)).ToList();
        allLengths.RemoveAt(allLengths.Count - 1);
        _displayCollection.Display(allLengths, SpecialCharacters.Separator);

        var longestWord = sentence.Split(delimiters).
            Aggregate((longestWordSoFar, nextWord)
                => nextWord.Length > longestWordSoFar.Length
                    ? nextWord : longestWordSoFar);
        _display.Display(longestWord);

        // The Letters
        List<string> letters = new() { "a", "b", "c", "d", "e" };
        var joinLetters = letters.Aggregate((resultSoFar, nextLetter)
            => $"{resultSoFar}, {nextLetter}");
        _display.Display(joinLetters);

        var countOfLetters = letters.Aggregate(0, (countSoFar, nextLetter)
            => countSoFar + 1);
        _display.Display($"Number of letters : {countOfLetters}");
    }

    public void ConcatAndUnion()
    {
        _display.Display($"{SpecialCharacters.NewLine}Concat Method:-");

        int[] integers = new[] { 1, 2, 1, 2 };
        int[] naturalNumbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        var allNumbers = integers.Concat(naturalNumbers);
        _displayCollection.Display(allNumbers, SpecialCharacters.Separator);

        var allNumbersNoDuplicate = naturalNumbers.Union(integers);
        _displayCollection.Display(allNumbersNoDuplicate, SpecialCharacters.Separator);
    }

    public void RepeatMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Repeat Method");

        var tenCopiesOf50 = Enumerable.Repeat(50, 10);
        _displayCollection.Display(tenCopiesOf50, SpecialCharacters.Separator);

    }

    public void GroupBy()
    {
        _display.Display($"{SpecialCharacters.NewLine}Group By:-");

        List<IStudent> students = new()
        {
            new Student("Adam", "Smith", 18, 1000, 8.0F),
            new Student("John", "Atkinson", 14, 1001, 9.0F),
            new Student("Jack", "Stuarts", 13, 1002, 7.0F),
            new Student("Brett", "Parker", 12, 1003, 8.0F),
            new Student("Samantha", "Potts", 15, 1004, 9.0F),
        };

        // var studentsGroupedByGrade = from student in students
        //                              group student by student.Grade;
        // OR
        var studentsGroupedByGrade = students.GroupBy(student => student.Grade);
        var ageSumByGrade = studentsGroupedByGrade.ToDictionary(
            group => group.Key,
            group => group.Sum(student => student.Age)
        );

        _displayCollection.Display(ageSumByGrade, SpecialCharacters.NewLine);
    }

    public void IntersectAndExcept()
    {
        _display.Display($"{SpecialCharacters.NewLine}Intersect:-");

        var collection = new[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        var collection2 = new[] { 1, 2, 11, 12 };

        var intersection = collection.Intersect(collection2);
        _displayCollection.Display(intersection, SpecialCharacters.Separator);

        var exclusiveToCollection2 = collection2.Except(collection);
        _displayCollection.Display(exclusiveToCollection2, SpecialCharacters.Separator);

        ArraySegment<IStudent> students1 = new[] {
            new Student("John", "", 10, 9, 7.9F),
            new Student("Harry", "", 10, 10, 7.9F)
        };

        ArraySegment<IStudent> students2 = new[] {
            new Student("John", "", 10, 9, 7.9F)
        };

        var studentsIntersection = students1.Intersect(students2);
        _displayCollection.Display(studentsIntersection, SpecialCharacters.NewLine);

        var studentsExclusion = students1.Except(students2);
        _displayCollection.Display(studentsExclusion, SpecialCharacters.NewLine);
    }

    public void JoinMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Join Method:-");

        ArraySegment<IStudent> students = new[] {
            new Student("John", "", 10, 9, 7.9F),
            new Student("Harry", "", 10, 10, 7.9F)
        };

        ArraySegment<IDepartment> departments = new[] {
            new Department(9, "Engineering", "CS"),
            new Department(10, "Business", "MS"),
        };

        var innerJoin = from student in students
                        join department in departments
                        on student.ID equals department.StudentID
                        select $"{department.Name} \t {student.ID} \t {department.Branch}";
        _displayCollection.Display(innerJoin, SpecialCharacters.NewLine);
    }

    public void SingleMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Single Method:-");

        int[] integers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // int[] integers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        var single = integers.SingleOrDefault(number => number > 9);

        _display.Display(single.ToString());
    }

    public void TakeMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Take Method:-");

        int[] integers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var takeFirst5Integers = integers.Take(5);
        var takeLast5Integers = integers.TakeLast(5);
        var takeIntegersLessThan10 = integers.TakeWhile(number => number < 10);

        _displayCollection.Display(takeFirst5Integers, SpecialCharacters.Separator);
        _displayCollection.Display(takeLast5Integers, SpecialCharacters.Separator);
        _displayCollection.Display(takeIntegersLessThan10, SpecialCharacters.Separator);
    }

    public void SkipMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Skip Method:-");

        int[] integers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var skipFirst5Integers = integers.Skip(integers.Length / 2);
        var take4thAnd5thIntegers = integers.Skip(3).Take(2);

        _displayCollection.Display(skipFirst5Integers, SpecialCharacters.Separator);
        _displayCollection.Display(take4thAnd5thIntegers, SpecialCharacters.Separator);
    }

    public void ZipMethod()
    {
        _display.Display($"{SpecialCharacters.NewLine}Zip Method:-");

        int[] naturalNumbers = Enumerable.Range(1, 26).ToArray();
        char[] alphabets = Enumerable.Range('A', 26).
            Select(number => (char)number).ToArray();

        var naturalNumbersZippedWithAlphabets = naturalNumbers.Zip(alphabets,
            (number, character) => $"{number} : {character}");
        _displayCollection.Display(
            naturalNumbersZippedWithAlphabets, SpecialCharacters.Separator);
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