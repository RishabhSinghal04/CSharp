
public readonly record struct Rectangle(decimal Length, decimal Breadth)
{
    public static decimal Area(Rectangle rectangle)
        => rectangle.Length * rectangle.Breadth;

    // Relational Operators
    public static bool operator <(Rectangle left, Rectangle right)
        => Area(left) < Area(right);

    public static bool operator >(Rectangle left, Rectangle right)
        => Area(left) > Area(right);

    public static bool operator <=(Rectangle left, Rectangle right)
        => Area(left) <= Area(right);

    public static bool operator >=(Rectangle left, Rectangle right)
        => Area(left) >= Area(right);

    // Arithematic Operators
    public static Rectangle operator +(Rectangle left, Rectangle right)
        => new(left.Length + right.Length, left.Breadth + right.Breadth);

    /// <summary>
    /// For left = Rectangle1(Length, Breadth) and right = Rectangle2(Length, Breadth) 
    /// <para> => Rectangle1 - Rectangle2 </para>
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns>Rectangle</returns>
    public static Rectangle operator -(Rectangle left, Rectangle right)
        => new(left.Length - right.Length, left.Breadth - right.Breadth);

    public static Rectangle operator *(Rectangle left, Rectangle right)
        => new(left.Length * right.Length, left.Breadth * right.Breadth);

    /// <summary>
    /// For left = Rectangle1(Length, Breadth) and right = Rectangle2(Length, Breadth) 
    /// <para> => Rectangle1 / Rectangle2 </para>
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns>Rectangle</returns>
    /// <exception cref="DivideByZeroException"></exception>
    public static Rectangle operator /(Rectangle left, Rectangle right)
    {
        if (right.Length == 0 || right.Breadth == 0)
        {
            throw new DivideByZeroException("cannot divide by zero");
        }
        return new(left.Length / right.Length, left.Breadth / right.Breadth);
    }
}

public static class RectangleFactory
{
    public static Rectangle Create(decimal Length, decimal Breadth)
    {
        if (Length <= 0)
        {
            throw new ArgumentException($"{nameof(Length)} must be greater than 0");
        }
        else if (Breadth <= 0)
        {
            throw new ArgumentException($"{nameof(Breadth)} must be greater than 0");
        }
        return new Rectangle(Length, Breadth);
    }
}