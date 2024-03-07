
using System.Reflection;
using AdvancedCSharpTypes.UserInteraction;

public class ObjectInformation
{
    public static void Display(object obj)
    {
        IDisplay display = new DisplayOnConsole();
        IDisplayEnumerable displayEnumerable = new DisplayEnumerableOnConsole(display);

        // Get the Type information
        Type typeInfo = obj.GetType();

        // Display the full name
        display.DisplayLine($"***** Full Name : {typeInfo.FullName}");

        // Get and display the property information
        display.Display("**** Property/Properties:-");
        PropertyInfo[] properties = typeInfo.GetProperties();
        displayEnumerable.Display(properties, ", ");

        // Get and display method information
        display.Display("**** Method(s):-");
        MethodInfo[] methods = typeInfo.GetMethods();
        displayEnumerable.Display(methods, ", ");
    }
}
