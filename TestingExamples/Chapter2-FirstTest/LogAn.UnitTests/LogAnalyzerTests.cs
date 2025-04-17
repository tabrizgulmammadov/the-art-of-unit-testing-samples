using NUnit.Framework;

namespace LogAn.UnitTests;

[TestFixture]
public class LogAnalyzerTests
{
    private LogAnalyzer m_analyzer=null;
    
    [SetUp] 
    public void SetUp()
    {
        m_analyzer = MakeAnalyzer(); 
    }
    
    [Test]
    [Category("Fast Tests")]
    public void IsValidLogFileName_BadExtension_ReturnsFalse()
    {
        bool result = m_analyzer.IsValidLogFileName("filewithbadextension.foo");

        Assert.That(result, Is.False);
    }

    [TestCase("filewithgoodextension.SLF")]
    [TestCase("filewithgoodextension.slf")]
    [Category("Fast Tests")]
    public void IsValidLogFileName_ValidExtensions_ReturnTrue(string filename)
    {
        bool result = m_analyzer.IsValidLogFileName(filename);
        
        Assert.That(result, Is.True);
    }

    [TestCase("filewithgoodextension.SLF", true)]
    [TestCase("filewithgoodextension.slf", true)]
    [TestCase("filewithgoodextension.foo", false)]
    [Category("Fast Tests")]
    public void IsValidLogFileName_VariousExtensions_ReturnTrue(string filename, bool isValid)
    {
        bool result = m_analyzer.IsValidLogFileName(filename);
        
        Assert.That(result, Is.EqualTo(isValid));
    }

    [Test]
    [Category("Slow Tests")]
    public void IsValidLogFileName_EmptyFileName_ThrowsException()
    {
        var exception = Assert.Catch<Exception>(() => m_analyzer.IsValidLogFileName(string.Empty));
        Assert.That(exception.Message, Does.Contain("filename has to be provided"));
    }

    [TestCase("badfile.foo", false)]
    [TestCase("goodfile.slf", true)]
    public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName, bool expected)
    {
        m_analyzer.IsValidLogFileName(fileName);
        Assert.That(m_analyzer.WasLastFileNameValid, Is.EqualTo(expected));
    }

    [TearDown]
    public void TearDown()
    {
        m_analyzer = null;
    }

    private LogAnalyzer MakeAnalyzer()
    {
        return new LogAnalyzer();
    }
}