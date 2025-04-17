using NSubstitute;
using NUnit.Framework;

namespace LogAn.UnitItems;

[TestFixture]
public class LogAnalyzerTests
{
    [Test]
    public void Analyze_TooShortFileName_CallLogger()
    {
        // Arrange
        var logger = Substitute.For<ILogger>();
        var logAnalyzer = new LogAnalyzer(logger)
        {
            MinNameLength = 6
        };

        // Act
        logAnalyzer.Analyze("a.txt");

        // Assert
        logger.Received().LogError("Filename too short: a.txt");
    }

    [Test]
    public void IsValidLogFileName_ByDefault_WorksForHardCodedArgument()
    {
        // Arrange
        IFileNameRules fileNameRules = Substitute.For<IFileNameRules>();
        fileNameRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);

        // Act
        bool isValid = fileNameRules.IsValidLogFileName("short.txt");

        // Assert
        Assert.That(isValid, Is.True);
    }

    [Test]
    public void IsValidLogFileName_ArgAny_ThrowsException()
    {
        // Arrange
        IFileNameRules fileNameRules = Substitute.For<IFileNameRules>();
        fileNameRules
            .When(x => x.IsValidLogFileName(Arg.Any<string>()))
            .Do(_ => throw new Exception("fake exception"));

        // Assert
        Assert.Throws<Exception>(() => fileNameRules.IsValidLogFileName("anything"));
    }
}