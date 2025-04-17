using NUnit.Framework;

namespace LogAn.UnitTests;

[TestFixture]
public class MemCalculatorTests
{
    [Test]
    public void Sum_ByDefault_ReturnsZero()
    {
        var memCalculator = MakeMemCalculator();
        
        int lastSum = memCalculator.Sum();

        Assert.That(lastSum, Is.EqualTo(0));
    }

    [Test]
    public void Add_WhenCalled_ChangesSum()
    {
        var memCalculator = MakeMemCalculator();
        
        memCalculator.Add(1);
        int sum = memCalculator.Sum();
        
        Assert.That(sum, Is.EqualTo(1));
    }

    private MemCalculator MakeMemCalculator()
    {
        return new MemCalculator();
    }
}