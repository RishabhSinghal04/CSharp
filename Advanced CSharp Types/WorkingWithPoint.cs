using AdvancedCSharpTypes.UserInteraction;

public class WorkingWithPoint
{
    private readonly IDisplay display;

    public WorkingWithPoint(IDisplay display)
    {
        this.display = display;
    }

    public void Work()
    {
        display.DisplayLine($"{Environment.NewLine}***** Working with points:-");

        Point point = new(1, 2);
        display.DisplayLine($"Original point is {point}");

        Point pointMoved = point with { X = 10 };
        display.DisplayLine($"Changed value of X is {pointMoved}");

        Point pointMovedBy1 = point with { X = point.X + 1, Y = point.Y + 1 };
        display.DisplayLine($"Increment {point} by 1 : {pointMovedBy1}");

        Point pointMovedBy2 = point with { X = 2, Y = 4 };
        display.DisplayLine($"Increment {point} by 2 : {pointMovedBy2}");


        display.DisplayLine("Arithmetic Operations:-");
        Point point1 = new(10.5, 40);
        Point point2 = new(1100, 1234.5);

        display.Display($"Point1 = {point1}");
        display.DisplayLine($"and Point2 = {point2}");
        display.DisplayLine($"{point1} + {point2} = {point1 + point2}");
        display.DisplayLine($"{point1} - {point2} = {point1 - point2}");
        display.DisplayLine($"{point1} * {point2} = {point1 * point2}");
        display.DisplayLine($"{point2} / {point1} = {point2 / point1}");
        point1 += point2;
        display.DisplayLine($"point1 += point2 is {point1}");

        Point point3 = new(0, 10);
        Point point4 = point3;
        display.Display($"Point3 = {point3}");
        display.DisplayLine($"and Point4 = {point4}");
        try
        {
            display.DisplayLine($"{point3} / {point4} = {point3 / point4}");
        }
        catch (DivideByZeroException ex)
        {
            display.DisplayLine($"Exception caught: {ex.Message}");
        }

        display.DisplayLine("Check for equality:-");
        display.DisplayLine($"{point3.Equals(point4)}");
        display.DisplayLine($"{point3 == point4}");
        display.DisplayLine($"{point3 != point4}");

        display.DisplayLine("Relational Operators:-");
        display.DisplayLine($"{point3 > point4}");
        display.DisplayLine($"{point3 < point4}");
        display.DisplayLine($"{point3 >= point4}");
        display.DisplayLine($"{point3 <= point4}");
    }
}