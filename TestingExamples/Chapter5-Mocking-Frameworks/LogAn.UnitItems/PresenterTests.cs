using NSubstitute;
using NUnit.Framework;

namespace LogAn.UnitItems;

[TestFixture]
public class PresenterTests
{
    [Test]
    public void Ctor_WhenViewIsLoaded_CallsViewRender()
    {
        // Arrange
        var mockView = Substitute.For<IView>();
        var stubLogger = Substitute.For<ILogger>();
        var presenter = new Presenter(mockView, stubLogger);

        // Act
        mockView.Loaded += Raise.Event<Action>();

        // Assert
        mockView
            .Received()
            .Render(
                Arg.Is<string>(s => s.Contains("Hello World"))
            );
    }

    [Test]
    public void Ctor_WhenViewHasError_CallsLogger()
    {
        // Arrange
        var stubView = Substitute.For<IView>();
        var mockLogger = Substitute.For<ILogger>();
        var presenter = new Presenter(stubView, mockLogger);

        // Act
        // Simulate the error
        stubView.ErrorOccured += Raise.Event<Action<string>>("fake error");

        // Assert
        // Uses mock to check log call
        mockLogger
            .Received()
            .LogError(
                Arg.Is<string>(s => s.Contains("fake error"))
            );
    }
}