using Generics.UserInteraction;

public class GenericsConsoleApp
{
    public void Run()
    {
        WorkingWithNumbers workingWithNumbers = new(new DisplayListOfNumbers());
        workingWithNumbers.Work();

        List<Person> people = new()
        {
            new Person("John", 1990),
            new Person("Jack", 1985),
            new Person("Jane", 1992),
            new Person("Janson", 1994),
        };

        foreach (var person in people)
        {
            Console.WriteLine(person);
        }

        people.Sort();
        Console.WriteLine("After sorting:-");

        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }
}
