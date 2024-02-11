namespace Display.People;

public class Person : IPerson
{
    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }

    public Person(in string firstName, in string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        ValidateAge(age);
        Age = age;
    }

    private static void ValidateAge(int age)
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