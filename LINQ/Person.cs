
public class Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }

    public Person(in string firstName, in string lastName, in int age)
    {
        FirstName = firstName;
        LastName = lastName;
        ValidateAge(age);
        Age = age;
    }

    private void ValidateAge(int age)
    {
        const int minAge = 0, maxAge = 200;

        if (age < minAge || age > maxAge)
        {
            throw new ArgumentException(
                $"Age of a person cannot be less than {minAge} or greater than {maxAge}");
        }
    }

    public override string ToString() => $"{FirstName} {LastName} \t {Age}";
}