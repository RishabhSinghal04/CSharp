
class Person : IComparable<Person>
{
    private int _birthYear;

    public string? Name { get; set; }
    public int BirthYear
    {
        get { return _birthYear; }
        set
        {
            if (value < 0 || value > DateTime.Now.Year)
            {
                throw new ArgumentException("Birth Year cannot be greater than " +
                    DateTime.Now.Year);
            }
            _birthYear = value;
        }
    }

    public Person(string name, int birthYear)
    {
        Name = name;
        BirthYear = birthYear;
    }

    public override string ToString() => $"Name : {Name} \t Year of Birth : {BirthYear}"
        + Environment.NewLine;

    public int CompareTo(Person? other)
    {
        if (other is null)
        {
            throw new ArgumentNullException("Object of class Person cannot be null");
        }
        return BirthYear < other.BirthYear
                ? 1 : BirthYear > other.BirthYear
                ? -1 : 0;
    }
}