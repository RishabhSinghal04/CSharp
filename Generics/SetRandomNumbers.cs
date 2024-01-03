
using System.Numerics;

public class SetRandomNumbers
{
    private static readonly Random random = new();

    public static void Set<T>(List<T> list, T MIN, T MAX) where T : INumber<T>
    {
        if (list.Capacity == 0)
        {
            return;
        }
        else if (MIN > MAX)
        {
            (MIN, MAX) = (MAX, MIN);
        }

        dynamic TMin = MIN, TMax = MAX;
        dynamic[] randomNumbers = IsFloatingPoint<T>()
            ? GenerateRandomFlaotingPoints(list.Capacity, TMin, TMax)
            : GenerateRandomIntegers(list.Capacity, TMin, TMax);

        foreach (var number in randomNumbers)
        {
            list.Add((T)number);
        }
    }

    private static bool IsFloatingPoint<T>()
        => typeof(IFloatingPoint<>).IsAssignableFrom(typeof(T));

    private static dynamic[] GenerateRandomFlaotingPoints(int capacity,
        dynamic TMin, dynamic TMax)
    {
        dynamic[] randomNumbers = new dynamic[capacity];
        for (int index = 0; index < capacity; ++index)
        {
            randomNumbers[index] = random.NextDouble() * (TMax - TMin) + TMin;
        }
        return randomNumbers;
    }

    private static dynamic[] GenerateRandomIntegers(int capacity,
        dynamic TMin, dynamic TMax)
    {
        dynamic[] randomNumbers = new dynamic[capacity];
        for (int index = 0; index < capacity; ++index)
        {
            randomNumbers[index] = random.NextInt64() % (TMax - TMin) + TMin;
        }
        return randomNumbers;
    }
}