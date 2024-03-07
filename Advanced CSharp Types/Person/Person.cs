using AdvancedCSharpTypes.UserInteraction;

namespace AdvancedCSharpTypes.Person;

public class Person : IPerson
{
    [NameLengthValidate(2, 100)]
    public string Name { get; init; }
    public DateOnly BirthDate { get; init; }

    public Person(string name, DateOnly birthDate)
    {
        Name = name;
        BirthDateValidator.Validate(birthDate);
        BirthDate = birthDate;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class NameLengthValidateAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public NameLengthValidateAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}

public class Validator
{
    public static bool Validate(object obj)
    {
        IDisplay _display = new DisplayOnConsole();
        // Get object type
        var typeInfo = obj.GetType();

        // Get all properties of object where attribute is defined
        var propertiesToValidate = typeInfo.GetProperties()
            .Where(property => Attribute.IsDefined(
                property, typeof(NameLengthValidateAttribute)
            ));

        foreach (var property in propertiesToValidate)
        {
            object? propertyValue = property.GetValue(obj);

            // If property is not string type, throw exception
            if (propertyValue is not string)
            {
                throw new InvalidOperationException(
                    $"Attribute {nameof(NameLengthValidateAttribute)} can only be applied to strings"
                );
            }

            var value = (string)propertyValue;
            var attribute = (NameLengthValidateAttribute)property.GetCustomAttributes(
                typeof(NameLengthValidateAttribute), true).First();
            if (value.Length < attribute.Min || value.Length > attribute.Max)
            {
                _display.Display(
                    $"Property {property.Name} is Invalid and Value is {value}");
                return false;
            }
        }
        return true;
    }
}

public static class CalculateAge
{
    public static int Calculate(DateOnly birthDate)
    {
        BirthDateValidator.Validate(birthDate);

        DateOnly today = DateOnly.FromDateTime(DateTime.Today.Date);
        int age = today.Year - birthDate.Year;

        return today <= birthDate.AddYears(age) ? --age : age;
    }
}

public static class BirthDateValidator
{
    public static void Validate(DateOnly birthDate)
    {
        if (DateOnly.FromDateTime(DateTime.Today.Date) < birthDate)
        {
            throw new ArgumentException("Invalid Date Of Birth");
        }
    }
}