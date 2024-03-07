
[AttributeUsage(AttributeTargets.All)]
public class Author : Attribute
{
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
}