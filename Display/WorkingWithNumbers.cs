using Display.DisplayOnConsole.cs;

public class WorkingWithNumbers
{
    private const int MIN = -10, MAX = 10;
    private const string separator = ", ";
    private readonly Random random = new();

    public void Integers()
    {
        var integers = Enumerable.Range(0, 50)
            .AsParallel()
            .Select(num => random.Next(MIN, MAX));
        DisplayIntegersOnConsole.Display(integers, separator);
    }

    public void FloatingPoints()
    {
        var floatingPoints = Enumerable.Range(0, 70)
            .AsParallel()
            .Select(number => random.NextDouble() * (MAX - MIN) + MIN);
        DisplayFloatingPointsOnConsole.Display(floatingPoints, separator);
    }
}
