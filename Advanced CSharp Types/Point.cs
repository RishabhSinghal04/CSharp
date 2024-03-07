
public readonly struct Point : IEquatable<Point>
{
    public double X { get; init; }
    public double Y { get; init; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static double DistanceFromOrigin(Point point)
        => Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));

    public static double Distance(Point left, Point right)
        => Math.Sqrt(Math.Pow(left.X - right.X, 2) + Math.Pow(left.Y - right.Y, 2));

    public override readonly string ToString()
        => $"({X}, {Y})";

    // Equals Methods
    public readonly bool Equals(Point other)
        => X == other.X && Y == other.Y;

    public override readonly bool Equals(object? obj)
        => obj is Point point && Equals(point);

    // Equality Operators
    public static bool operator ==(Point left, Point right)
        => left.Equals(right);

    public static bool operator !=(Point left, Point right)
        => !(left == right);

    // Relational Operators
    public static bool operator <(Point left, Point right)
        => DistanceFromOrigin(left) < DistanceFromOrigin(right);

    public static bool operator >(Point left, Point right)
        => DistanceFromOrigin(left) > DistanceFromOrigin(right);

    public static bool operator <=(Point left, Point right)
        => DistanceFromOrigin(left) <= DistanceFromOrigin(right);

    public static bool operator >=(Point left, Point right)
        => DistanceFromOrigin(left) >= DistanceFromOrigin(right);

    // Arithematic Operators
    public static Point operator +(Point left, Point right)
        => new(left.X + right.X, left.Y + right.Y);

    /// <summary>
    /// For left = P1(x1, y1) and right = P2(x2, y2) 
    /// <para> => P1 - P2 = x1 - x2, y1 - y2</para>
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns>Point</returns>
    public static Point operator -(Point left, Point right)
        => new(left.X - right.X, left.Y - right.Y);

    public static Point operator *(Point left, Point right)
        => new(left.X * right.X, left.Y * right.Y);

    /// <summary>
    /// For left = P1(x1, y1) and right = P2(x2, y2) 
    /// <para> => P1 / P2 = x1 / x2, y1 / y2</para>
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns>Point</returns>
    /// <exception cref="DivideByZeroException"></exception>
    public static Point operator /(Point left, Point right)
    {
        if (right.X == 0 || right.Y == 0)
        {
            throw new DivideByZeroException("cannot divide by zero");
        }
        return new(left.X / right.X, left.Y / right.Y);
    }

    public override int GetHashCode()
         => HashCode.Combine(X, Y);
}