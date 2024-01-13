namespace Linq.People;

public interface IStudent : IPerson
{
    float Grade { get; }
    int ID { get; }
}