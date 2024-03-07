namespace AdvancedCSharpTypes.Person;

public interface IPerson
{
    string Name { get; init; }
    DateOnly BirthDate { get; init; }
}