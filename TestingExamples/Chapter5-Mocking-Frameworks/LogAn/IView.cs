namespace LogAn;

public interface IView
{
    event Action Loaded;
    event Action<string> ErrorOccured;
    void Render(string text);
}