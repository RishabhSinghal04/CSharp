
using AdvancedCSharpTypes.Person;
using AdvancedCSharpTypes.UserInteraction;
using static System.Environment;

#nullable disable
string text = null; // No Warning
if (text is null)
{ }
#nullable enable
// string otherText = null; // Warning 

IDisplay display = new DisplayOnConsole();
// Book book = new("The Adventure of The Empty House");

try
{
    WeatherData weatherData = new(25.1m, 65);
    var warmerWeather = weatherData with { Temperature = 30 };
    display.DisplayLine("Weather Data:-");
    display.DisplayLine("Temparature \t Humidity");
    display.DisplayLine($"{weatherData.Temperature} \t\t {weatherData.Humidity}");
    display.DisplayLine($"{warmerWeather.Temperature} \t\t {warmerWeather.Humidity}");

    // Rectangle rectangle = RectangleFactory.Create(-10, 10);
    Rectangle rectangle1 = RectangleFactory.Create(1, 2);
    Rectangle rectangle2 = RectangleFactory.Create(2, 4);
    rectangle1 += rectangle2;
    display.DisplayLine($"Dimensions of rectangle are {rectangle1}");

    AdvancedCSharpTypesConsoleApp advancedCSharpTypesConsoleApp = new(
        display
    );
    advancedCSharpTypesConsoleApp.Run();
}
catch (Exception ex)
{
    display.DisplayLine($"{NewLine}Exception Caught : {ex.Message}");
}

display.DisplayLine($"{NewLine}Press any key to exit....");
Console.ReadKey();


public record WeatherData(decimal Temperature, int Humidity);

class AdvancedCSharpTypesConsoleApp
{
    private readonly IDisplay _display;

    public AdvancedCSharpTypesConsoleApp(IDisplay display)
    {
        _display = display;
    }

    public void Run()
    {
        ObjectInformation.Display(
            new Person("Adam", new DateOnly(2003, 02, 28))
        );
        Person p = new("A", new DateOnly(2003, 02, 28));
        Validator.Validate(p);

        DateOnly birthDate = new(2003, 02, 27);
        Person person = new("John", birthDate);
        _display.DisplayLine(
            $"{NewLine}John is {CalculateAge.Calculate(birthDate)} years old");
        Validator.Validate(person);

        _display.DisplayLine(ObjectToTextConverter.Convert(
            new House("123 Maple Road", 170.2, 4)
        ));

        // Get all the attributes of class "Book"
        var attributes = Attribute.GetCustomAttributes(typeof(Book));

        // Retrieve the author attribute
        var author = attributes.OfType<Author>().Single();
        _display.DisplayLine(
            $"{NewLine}{author.FirstName} {author.MiddleName} {author.LastName}");

        WorkingWithPoint workingWithPoint = new(_display);
        workingWithPoint.Work();

        Nullable<bool> @bool = null;
        // Nullable<string> @string = null; // error, string is not value type
        List<Nullable<int>> heights = new() {
            160, null, 185, null, 170
        };

        /* var averageHeight = heights.Where(height => height is not null)
            .Average(); */
        // OR
        var averageHeight = heights.Average();
        _display.DisplayLine($"Average Height is {averageHeight}{@bool}");

    }
}

public record Pet(string Name, PetType PetType, float Weight);
public record House(string Address, double Area, int Floor);
public enum PetType
{
    Cat,
    Dog,
    Fish
}
