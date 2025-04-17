using NUnit.Framework;

namespace LogAn.UnitTests;

[TestFixture]
public class LogAnalyzerUsingFactoryMethodTests
{
    [Test]
    public void IsValidLogFileName_OverrideFunc_ReturnsTrue()
    {
        FakeExtensionManager stub = new FakeExtensionManager();
        stub.WillBeValid = true;

        TestableLogAnalyzer logan = new TestableLogAnalyzer(stub);

        bool result = logan.IsValidLogFileName("file.txt");

        Assert.That(result, Is.True);
    }
}