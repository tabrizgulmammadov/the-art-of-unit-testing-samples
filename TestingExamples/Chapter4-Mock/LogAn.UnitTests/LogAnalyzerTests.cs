using NUnit.Framework;

namespace LogAn.UnitTests;

[TestFixture]
public class LogAnalyzerTests
{
    [Test]
    public void Analyze_TooShortFileName_CallsWebService()
    {
        FakeWebService mockWebService = new FakeWebService();
        FakeEmailService stubEmailService = new FakeEmailService();

        LogAnalyzer logAnalyzer = new LogAnalyzer(mockWebService, stubEmailService);

        string tooShortFilename = "abc.txt";
        logAnalyzer.Analyze(tooShortFilename);

        Assert.That(mockWebService.LastError, Does.Contain("Filename too short:abc.txt")); // from LogAn/LogAnalyzer
    }

    [Test]
    public void Analyze_WebServiceThrows_SendsEmail()
    {
        FakeWebService stubWebService = new FakeWebService();
        string errorMessage = "fake exception";
        stubWebService.ToThrow = new Exception(errorMessage);

        FakeEmailService mockEmailService = new FakeEmailService();

        LogAnalyzer logAnalyzer = new LogAnalyzer(stubWebService, mockEmailService);

        string tooShortFilename = "abc.txt";
        logAnalyzer.Analyze(tooShortFilename);

        Assert.That(mockEmailService.To, Does.Contain("a@mail.com")); // from LogAn/LogAnalyzer
        Assert.That(mockEmailService.Body, Does.Contain(errorMessage));
        Assert.That(mockEmailService.Subject, Does.Contain("Can't log")); // from LogAn/LogAnalyzer
    }
}