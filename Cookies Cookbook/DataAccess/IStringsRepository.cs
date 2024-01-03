namespace CookiesCookbook.DataAccess;

public interface IStringsRepository
{
    List<string> Read(in string filePath);
    void Write(in string filePath, List<string> strings);
}