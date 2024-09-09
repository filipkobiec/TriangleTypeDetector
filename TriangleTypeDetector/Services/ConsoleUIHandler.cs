using TriangleTypeDetector.Interfaces;

namespace TriangleTypeDetector.Services;

public class ConsoleUIHandler : IUIHandler
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}