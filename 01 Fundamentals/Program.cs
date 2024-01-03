
using System;
using System.Globalization;
using System.Numerics;

class Program
{
    int a = 10;
    static int b = 20;
    const int c = 30;
    readonly int d;

    public Program() { d = 40; }

    private static dynamic Add(dynamic a, dynamic b)
    {
        return a + b;
    }

    private static void InputOutput()
    {
        string? name;
        string str = "STRING";

        Console.Write("Hello");
        Console.WriteLine(" World");
        Console.WriteLine("Welcome");
        Console.Write("Enter " + "your" + " name : ");
        name = Console.ReadLine();
        Console.WriteLine("Hi! {0}", name);
        // String.Format
        Console.WriteLine(string.Format("{0, -10}", $"Hello, {name}"));
        Console.WriteLine(str.PadLeft(10));
        Console.WriteLine(str.PadRight(10));

        // Default
        Console.WriteLine("\nDefault Values:-");
        Console.WriteLine($"byte : {default(byte)}");
        Console.WriteLine($"short : {default(short)}");
        Console.WriteLine($"int : {default(int)}");
        Console.WriteLine($"long : {default(long)}");
        Console.WriteLine($"Int128 : {default(Int128)}");
        Console.WriteLine($"sbyte : {default(float)}");
        Console.WriteLine($"sbyte : {default(double)}");
        Console.WriteLine($"sbyte : {default(decimal)}");
        Console.WriteLine($"sbyte : {default(bool)}");

        // Reading numeric values
        Console.WriteLine("\nReading Numeric Values:-");
        sbyte byte_value;
        short small_integer;
        int integer;
        ulong long_integer;
        float small_floating_point_num;
        double floating_point_num;
        decimal decimal_num;

        Console.Write("\nEnter byte: ");
        byte_value = Convert.ToSByte(Console.ReadLine());
        Console.Write("\nEnter small integer: ");
        small_integer = Convert.ToInt16(Console.ReadLine());
        Console.Write("\nEnter integer: ");
        integer = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nEnter long integer: ");
        long_integer = Convert.ToUInt32(Console.ReadLine());

        Console.Write("\nEnter small floating point number: ");
        small_floating_point_num = (float)Convert.ToDouble(Console.ReadLine());
        Console.Write("\nEnter floating point number: ");
        floating_point_num = Convert.ToDouble(Console.ReadLine());
        Console.Write("\nEnter large floating number: ");
        decimal_num = Convert.ToDecimal(Console.ReadLine());

        // Using TryParse()
        string? input;

        Console.Write("Enter a number: ");
        input = Console.ReadLine();

        /* string message = int.TryParse(input, out num)
        ? "It's a number"
        : "It is not a number"; */

        Console.WriteLine(int.TryParse(input, out int num)
        ? "It's a number" : "It is not a number");

        Console.WriteLine($"'{num}' after incrementing by 1 is {++num}");

        // Setprecision
        Console.Write("Enter a floating point number: ");
        input = Console.ReadLine();

        NumberFormatInfo setPrecision = new()
        {
            NumberDecimalDigits = 2
        };

        Console.WriteLine(double.TryParse(input, out double floating_point_number)
        ? floating_point_number.ToString("N", setPrecision) : "It's not a number");

        // Numerical Format Characters
        NumberFormatInfo currency = new CultureInfo("en-US", false).NumberFormat;
        currency = (NumberFormatInfo)currency.Clone();
        currency.CurrencySymbol = "Rs";

        Console.WriteLine("""The value "99999" in various formats:-""");
        Console.WriteLine("C Format : {0:C}", 99999);
        Console.WriteLine("C Format : {0}", 99999.ToString("C", currency));
        Console.WriteLine("d9 Format : {0:d9}", 99999);
        Console.WriteLine("f3 Format : {0:f3}", 99999);
        Console.WriteLine("n Format : {0:n}", 99999);
        Console.WriteLine("E Format : {0:E}", 99999);
        Console.WriteLine("e Format : {0:e}", 99999);
        Console.WriteLine("X Format : {0:X}", 99999);
        Console.WriteLine("x Format : {0:x}", 99999);

        // Big Integer
        BigInteger bigNum = BigInteger.Parse("1234567890098765432112345");
        BigInteger bigNum2 = BigInteger.Parse("1234567890098765432112345");

        BigInteger bigSum = bigNum + bigNum2;
        Console.WriteLine($"Sum of two big integers is {bigSum}");
    }

    private static void MaxMin()
    {
        Console.WriteLine("\n\nMax and Min:-");

        // Integers
        Console.WriteLine("sbyte min value : " + sbyte.MinValue);
        Console.WriteLine("sbyte max value : " + sbyte.MaxValue);
        Console.WriteLine("byte min value : " + byte.MinValue);
        Console.WriteLine("byte max value : " + byte.MaxValue);
        Console.WriteLine("short min value : " + short.MinValue);
        Console.WriteLine("short max value : " + short.MaxValue);
        Console.WriteLine("ushort min value : " + ushort.MinValue);
        Console.WriteLine("ushort max value : " + ushort.MaxValue);
        Console.WriteLine("int min value : " + int.MinValue);
        Console.WriteLine("int max value : " + int.MaxValue);
        Console.WriteLine("uint min value : " + uint.MinValue);
        Console.WriteLine("uint max value : " + uint.MaxValue);
        Console.WriteLine("long min value : " + long.MinValue);
        Console.WriteLine("long max value : " + long.MaxValue);
        Console.WriteLine("ulong min value : " + ulong.MinValue);
        Console.WriteLine("ulong max value : " + ulong.MaxValue);
        Console.WriteLine("long long min value : " + Int128.MinValue);
        Console.WriteLine("long long max value : " + Int128.MaxValue);
        Console.WriteLine("ulong long min value : " + UInt128.MinValue);
        Console.WriteLine("ulong long max value : " + UInt128.MaxValue);

        // Floating Points
        Console.WriteLine("float min value : " + float.MinValue);
        Console.WriteLine("float max value : " + float.MaxValue);
        Console.WriteLine("double min value : " + double.MinValue);
        Console.WriteLine("double max value : " + double.MaxValue);
        Console.WriteLine("decimal min value : " + decimal.MinValue);
        Console.WriteLine("decimal max value : " + decimal.MaxValue);
    }

    private static void Variable()
    {
        Console.WriteLine("\n\nVariables:-");
        Program obj = new();

        Console.WriteLine($"Instance variable 'a' = {obj.a}");
        Console.WriteLine($"Static variable 'b' = {b}");
        Console.WriteLine($"Constant variable 'c' = {c}");
        Console.WriteLine($"Instance variable 'd' = {obj.d}");

        var num = 10;
        Console.WriteLine($"Value of num (type var) is {num}");

        dynamic num_1 = 10, num_2 = 40;
        Console.WriteLine($"Value of num_2 (type dynamic) is {num_2}");

        dynamic sum = Add(num_1, num_2);
        Console.WriteLine($"Sum of {num_1} and {num_2} is {sum}");
    }

    private static void DateAndTime()
    {
        Console.WriteLine("\n\nDate and Time:-");

        DateTime dt1 = new(2000, 1, 1);
        Console.WriteLine(dt1.ToString());

        DateTime dt2 = new(2000, 12, 10, 0, 1, 2);
        Console.WriteLine(dt2);
    }

    private static void NullOperators()
    {
        string? a;
        Console.WriteLine("Enter a string: ");
        a = Console.ReadLine();

        var b = a ?? "'a' is null";
        Console.WriteLine($"Value of 'b' is {b}");
    }

    private static void RandomNumbers()
    {
        Console.WriteLine("\n\nRandom Numbers:-");
        Random rand = new();

        for (int i = 0; i < 2; ++i)
        {
            Console.WriteLine(rand.Next());
        }

        for (int i = 0; i < 2; ++i)
        {
            Console.WriteLine(rand.Next(-10, 10));
        }

        int MAX = 10, MIN = -10;
        for (int i = 0; i < 10; ++i)
        {
            Console.WriteLine(rand.NextDouble() * (MAX - MIN) + MIN);
        }
    }

    static void Main(string[] args)
    {
        // InputOutput();
        // MaxMin();
        // Variable();
        DateAndTime();
        RandomNumbers();

        Console.ReadKey();
    }
}