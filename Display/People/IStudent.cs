namespace Display.People;

public interface IStudent : IPerson
{
    float Grade { get; }
    int ID { get; }
}