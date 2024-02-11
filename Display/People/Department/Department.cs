
namespace Display.People.Department;

public class Department : IDepartment
{
    public int StudentID { get; }
    public string Name { get; }
    public string Branch { get; }

    public Department(int studentID, string name, string branch)
    {
        Validation.ValidateID(studentID);
        StudentID = studentID;
        Name = name;
        Branch = branch;
    }

    public override bool Equals(object? obj)
        => obj is not null
            && obj.GetType() == GetType()
            && ((Department)obj).Name == Name;

    public override string ToString()
        => $"{StudentID} \t {Name} \t {Branch}";

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}