
namespace GameDataParser.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public string ReadValidFilePath()
    {
        do
        {
            Console.Write("Enter file name that you want to read: ");
            string? fileName = Console.ReadLine();

            if (string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("File name cannot be null or empty");
            }
            else if (!File.Exists(fileName))
            {
                Console.WriteLine("File does not exist");
            }
            else
            {
                return fileName;
            }
        }
        while (true);
    }

    public void DisplayMessage(in string message)
    {
        Console.WriteLine(message);
    }

    public void DisplayError(in string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }
}