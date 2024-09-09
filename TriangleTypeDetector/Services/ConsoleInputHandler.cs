using TriangleTypeDetector.Interfaces;

namespace TriangleTypeDetector.Services;

public class ConsoleInputHandler : IInputHandler
{
    private readonly IUIHandler _uiHandler;

    public ConsoleInputHandler(IUIHandler uiHandler)
    {
        _uiHandler = uiHandler;
    }
    public int GetTriangleSide(string prompt)
    {
        int result;
        bool isValid;
        do
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            isValid = int.TryParse(input, out result) && result > 0;
            if (!isValid)
            {
                _uiHandler.ShowMessage("Invalid input. Please enter a positive integer.");
            }
        } while (!isValid);
        return result;
    }
}