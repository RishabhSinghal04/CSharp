
namespace GameDataParser.Logging;

public class Logger
{
    private readonly string _logFileName;

    public Logger(string logFileName)
    {
        _logFileName = logFileName;
    }

    public void Log(Exception ex)
    {
        var entry =
        $@"[{DateTime.Now}]
        Exception Message: {ex.Message}
        Stack Trace: {ex.StackTrace}

        ";

        File.AppendAllText(_logFileName, entry);
    }
}