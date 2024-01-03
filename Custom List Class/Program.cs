
using CustomListClass;

CustomListClassFunction();
DisplayMinAndMax();

Console.WriteLine("Press any key to exit....");
Console.ReadKey();

static void CustomListClassFunction()
{
    // INTEGERS
    CustomList<int> integers = new();

    for (int i = 0; i < 50; i++)
    {
        integers.Add(i);
    }

    for (int index = 0; index < integers.Length; ++index)
    {
        Console.Write($"{integers[index]}, ");
    }
    Console.Write($"\b\b \b {Environment.NewLine}");

    try
    {
        integers.RemoveAt(47);
        integers.RemoveAt(0);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception Caught : " + ex.Message);
    }

    for (int index = 0; index < integers.Length; ++index)
    {
        Console.Write($"{integers[index]}, ");
    }
    Console.Write($"\b\b \b{Environment.NewLine}");

    // FLOATING POINTS
    CustomList<double> floatingPoints = new();

    for (int i = 0; i < 10; i++)
    {
        floatingPoints.Add(i * 1.2345);
    }

    for (int index = 0; index < floatingPoints.Length; ++index)
    {
        Console.Write($"{floatingPoints[index]}, ");
    }
    Console.Write($"\b\b \b {Environment.NewLine}");

    try
    {
        floatingPoints.RemoveAt(9);
        floatingPoints.RemoveAt(0);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception Caught : " + ex.Message);
    }

    for (int index = 0; index < floatingPoints.Length; ++index)
    {
        Console.Write($"{floatingPoints[index]}, ");
    }
    Console.Write($"\b\b \b{Environment.NewLine}");

    // STRINGS
    CustomList<string> strings = new();

    strings.Add("abcd");
    strings.Add("efgh");
    strings.Add("ijkl");
    strings.Add("mnop");
    strings.Add("qrst");
    strings.Add("uvw");
    strings.Add("xyz");

    for (int index = 0; index < strings.Length; ++index)
    {
        Console.Write($"{strings[index]}, ");
    }
    Console.Write($"\b\b \b{Environment.NewLine}");

    try
    {
        strings.RemoveAt(10);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception Caught : " + ex.Message);
    }
    Console.WriteLine(Environment.NewLine, Environment.NewLine);
}

static void DisplayMinAndMax()
{
    List<int> integers2 = new(10);
    List<double> floatingPoints2 = new(10);
    Random rand = new();
    const int MIN = -10, MAX = 10;

    for (int index = 0; index < integers2.Capacity; ++index)
    {
        integers2.Add(rand.Next(MIN, MAX));
    }
    integers2.AddToFront(11);

    foreach (var integer in integers2)
    {
        Console.Write($"{integer}, ");
    }
    Console.Write($"\b\b \b{Environment.NewLine}");

    (int min, int max) = Compare.MinAndMax(integers2);
    Console.WriteLine($"Min integer is {min} and max integer is {max}");
    Console.WriteLine();

    for (int index = 0; index < floatingPoints2.Capacity; ++index)
    {
        floatingPoints2.Add(rand.NextDouble() * (MAX - MIN) + MIN);
    }

    foreach (var floatingPoint in floatingPoints2)
    {
        Console.Write($"{floatingPoint}, ");
    }
    Console.Write($"\b\b \b{Environment.NewLine}");

    (double minFloatingPoint, double maxFloatingPoint) = Compare.MinAndMax(floatingPoints2);
    Console.WriteLine($"Min : {minFloatingPoint} and Max : {maxFloatingPoint}");
}

public class Compare
{
    public static (T min, T max) MinAndMax<T>(IEnumerable<T> items)
    where T : IComparable<T>
    {
        if (items == null || !items.Any())
        {
            throw new ArgumentException("Collection cannot be null or empty");
        }
        return (items.Min(), items.Max())!;
    }
}