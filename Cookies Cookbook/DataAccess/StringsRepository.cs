namespace CookiesCookbook.DataAccess;

public abstract class StringsRepository : IStringsRepository
{
    public List<string> Read(in string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContent = File.ReadAllText(filePath);
            return TextToStrings(fileContent);
        }
        return new List<string>();
    }

    protected abstract List<string> TextToStrings(string fileContent);

    public void Write(in string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, StringsToText(strings));
    }

    protected abstract string? StringsToText(List<string> strings);
}