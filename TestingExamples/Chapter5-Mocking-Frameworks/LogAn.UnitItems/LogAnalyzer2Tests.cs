using NSubstitute;
using NUnit.Framework;

namespace LogAn.UnitItems;

[TestFixture]
public class LogAnalyzer2Tests
{
    [Test]
    public void Analyze_LoggerThrows_CallsWebService()
    {
        // Arrange
        var mockWebService = Substitute.For<IWebService>();
        var stubLogger = Substitute.For<ILogger>();
        stubLogger
            .When(x => x.LogError(Arg.Any<string>()))
            .Do(_ => throw new Exception("fake exception"));

        var logAnalyzer = new LogAnalyzer2(stubLogger, mockWebService);
        
        // Act
        logAnalyzer.MinNameLength = 10;
        logAnalyzer.Analyze("short.txt");
        
        // Assert
        mockWebService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));
    }
}