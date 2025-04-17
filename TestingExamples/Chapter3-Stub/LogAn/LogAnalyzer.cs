namespace LogAn;

public class LogAnalyzer
{
    public IExtensionManager extentionManager;

    // constructor using DI
    public LogAnalyzer(IExtensionManager manager)
    {
        extentionManager = manager;
    }

    // constructor using FactoryMethod
    public LogAnalyzer()
    {
        extentionManager = ExtensionManagerFactory.Create();
    }

    public bool WasLastFileNameValid { get; set; }

    public bool IsValidLogFileName(string fileName)
    {
        return extentionManager.IsValid(fileName)
               && Path.GetFileNameWithoutExtension(fileName).Length > 5;
    }
}