
using DataProcessor;

/* List<string> commands = new()
{
    "--file",
    @"E:\Microsoft VS Code\Microsoft VS Code Save Programs\C# Programs\File Handling\data1.txt",
}; */

List<string> commands = new()
{
    "--dir",
    @"E:\Microsoft VS Code\Microsoft VS Code Save Programs\C# Programs\File Handling\",
    "Text"
};

var command = commands[0];

if (command == "--file")
{
    var filePath = commands[1];

    // Check if path is absolute
    if (!Path.IsPathFullyQualified(filePath))
    {
        Console.WriteLine($"ERROR: Path \"{filePath}\" must be qualified.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine($"Single file {filePath} selected");
    ProcessSingleFile(filePath);
}
else if (command == "--dir")
{
    var directoryPath = commands[1];
    var fileType = commands[2];
    Console.WriteLine($"Directory {directoryPath} selected for {fileType} files");
    ProcessDirectory(directoryPath, fileType);
}
else
{
    Console.WriteLine("Invalid Command Line Options");
}

Console.WriteLine("Press any key to exit....");
Console.ReadKey();

static void ProcessSingleFile(string filePath)
{
    var fileProcessor = new FileProcessor(filePath);
    fileProcessor.Process();
}

static void ProcessDirectory(string directoryPath, string fileType)
{
    // string[] allFiles = Directory.GetFiles(directoryPath);

    switch (fileType.ToLower())
    {
        case "text":
            string[] textFiles = Directory.GetFiles(directoryPath, "*.txt");
            foreach (var textFilePath in textFiles)
            {
                var fileProcessor = new FileProcessor(textFilePath);
                fileProcessor.Process();
            }
            break;

        default:
            Console.WriteLine($"ERROR : {fileType} not supported");
            break;
    }
}