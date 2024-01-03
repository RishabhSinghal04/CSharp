using Generics.UserInteraction;

public class WorkingWithNumbers
{
    private readonly IDisplayListOfNumbers _displayListOfNumbers;

    public WorkingWithNumbers(IDisplayListOfNumbers displayListOfNumbers)
    {
        _displayListOfNumbers = displayListOfNumbers;
    }

    public void Work()
    {
        const int MIN = -100, MAX = 101;
        List<int> integers = new(10);
        List<double> floatingPoints = new(10);
        List<uint> c = new(10);

        try
        {
            SetRandomNumbers.Set(integers, MIN, MAX);
            SetRandomNumbers.Set(floatingPoints, MIN, MAX);
            SetRandomNumbers.Set<uint>(c, 90, MAX);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Capacity must be greater than 0 " + ex.Message);
        }

        _displayListOfNumbers.Display(integers);
        _displayListOfNumbers.Display(floatingPoints);
        _displayListOfNumbers.Display(c);
    }
}