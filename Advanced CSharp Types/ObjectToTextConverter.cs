public static class ObjectToTextConverter
{
    public static string Convert(object obj)
    {
        // Get the type information
        Type typeInfo = obj.GetType();

        var properties = typeInfo.GetProperties()
            .Where(p => p.Name != "EqualityContract");

        return string.Join(", ", properties.Select(
                property => $"{property.Name} is {property.GetValue(obj)}"
        ));
    }
}
