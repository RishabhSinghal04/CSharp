namespace Display.People;

public static class Validation
{
    public static void ValidateID(int ID)
    {
        const int minID = 0, maxID = int.MaxValue;
        if (ID < 0 || ID > maxID)
        {
            throw new ArgumentException(
                $"Grade cannot be less than {minID} or greater than {maxID}");
        }
    }

    public static void ValidateGrade(float grade)
    {
        const float minGrade = 0.0F, maxGrade = 10.0F;
        if (grade < minGrade || grade > maxGrade)
        {
            throw new ArgumentException(
                $"Grade cannot be less than {minGrade} or greater than {maxGrade}");
        }
    }
}