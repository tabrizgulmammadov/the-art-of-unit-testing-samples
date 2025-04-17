namespace LogAn.UnitTests;

public class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod
{
    public IExtensionManager Manager;

    public TestableLogAnalyzer(IExtensionManager manager)
    {
        Manager = manager;
    }

    protected override IExtensionManager GetManager()
    {
        return Manager;
    }
}