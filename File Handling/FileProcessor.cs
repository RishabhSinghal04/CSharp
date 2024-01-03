
namespace DataProcessor;

class FileProcessor
{
    private const string backupDirName = "backup";
    private const string inProgressDirName = "processing";
    private const string completedDirName = "complete";

    public string? InputFilePath { get; }

    public FileProcessor(string filePath)
    {
        InputFilePath = filePath;
    }

    public void Process()
    {
        if (!File.Exists(InputFilePath))
        {
            Console.WriteLine($"ERROR : file {InputFilePath} does not exist");
            return;
        }

        Console.WriteLine($"Begin Process of {InputFilePath}");

        // Get root directory path
        string? rootDirectoryPath = (new DirectoryInfo(InputFilePath).Parent?.FullName)
        ?? throw new InvalidOperationException("Cannot determine root directory path"
            + $" {InputFilePath}");
        Console.WriteLine($"Root data path is {rootDirectoryPath}");

        // Create backup directory if it does not exists
        string backupDirPath = Path.Combine(rootDirectoryPath, backupDirName);
        if (!Directory.Exists(backupDirPath))
        {
            Console.WriteLine($"Creating {backupDirPath}");
            Directory.CreateDirectory(backupDirPath);
        }

        // Copy file to backup directory
        string inputFileName = Path.GetFileName(InputFilePath);
        string backupFilePath = Path.Combine(backupDirPath, inputFileName);

        Console.WriteLine($"Copying {InputFilePath} to {backupFilePath}");
        File.Copy(InputFilePath, backupFilePath, true);

        // Move file in progress directory
        Directory.CreateDirectory(Path.Combine(rootDirectoryPath, inProgressDirName));
        string inProgressFilePath = Path.Combine(rootDirectoryPath, inProgressDirName,
         inputFileName);

        if (File.Exists(inProgressFilePath))
        {
            Console.WriteLine($"ERROR: A file with the name {inProgressFilePath} already"
            + " being processed");
        }

        Console.WriteLine($"Moving {InputFilePath} to {inProgressFilePath}");
        File.Move(InputFilePath, inProgressFilePath);

        // Determine file extension
        string extension = Path.GetExtension(InputFilePath);
        switch (extension)
        {
            case ".txt":
                ProcessTextFile(inProgressFilePath);
                break;

            default:
                Console.WriteLine($"{extension} is an unsupported file type");
                break;
        }

        // Move file after processing is complete
        string completedDirPath = Path.Combine(rootDirectoryPath, completedDirName);
        Directory.CreateDirectory(completedDirPath);

        string fileNameWithCompletedExtension = Path.ChangeExtension(inputFileName,
         ".complete");
        string completeFileName = $"{Guid.NewGuid()}_{fileNameWithCompletedExtension}";
        string completeFilePath = Path.Combine(completedDirPath, completeFileName);

        Console.WriteLine($"Move {inProgressFilePath} to {completeFilePath}");
        File.Move(inProgressFilePath, completeFilePath);

        // Delete a directory
        string ? inProgressDirPath = Path.GetDirectoryName(inProgressFilePath);
        Directory.Delete(inProgressDirPath!, true);
    }

    private void ProcessTextFile(string inProgressFilePath)
    {
        Console.WriteLine($"Processing text file {inProgressFilePath}");
    }
}