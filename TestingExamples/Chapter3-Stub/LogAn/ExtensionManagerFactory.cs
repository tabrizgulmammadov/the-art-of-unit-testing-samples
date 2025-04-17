namespace LogAn;

public class ExtensionManagerFactory
{
    private static IExtensionManager _manager = null;

    public static IExtensionManager Create()
    {
        if (_manager is null)
        {
            return new FileExtensionManager();
        }

        return _manager;
    }

    public static void SetManager(IExtensionManager manager)
    {
        _manager = manager;
    }
}