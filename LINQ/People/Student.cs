
namespace Linq.People;

public class Student : Person, IStudent
{
    public float Grade { get; }
    public int ID { get; }

    public Student(in string firstName, in string lastName, int age, int ID, float grade)
        : base(firstName, lastName, age)
    {
        Validation.ValidateID(ID);
        this.ID = ID;
        Validation.ValidateGrade(grade);
        Grade = grade;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Student student = (Student)obj;
        return student.ID == ID &&
            student.FirstName == FirstName &&
            student.LastName == LastName;
    }

    public override int GetHashCode()
        => Tuple.Create(ID, FirstName, LastName).GetHashCode();

    public override string ToString()
        => base.ToString() + $"\t {ID} \t {Grade}";

}
