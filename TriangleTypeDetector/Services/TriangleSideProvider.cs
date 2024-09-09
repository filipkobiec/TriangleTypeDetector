using TriangleTypeDetector.Interfaces;

namespace TriangleTypeDetector.Services;

public class TriangleSideProvider : ITriangleSideProvider
{
    private readonly IInputHandler _inputHandler;
    private readonly IUIHandler _uiHandler;

    public TriangleSideProvider(IInputHandler inputHandler, IUIHandler uiHandler)
    {
        _inputHandler = inputHandler;
        _uiHandler = uiHandler;
    }

    public int[] GetTriangleSides()
    {
        _uiHandler.ShowMessage("Please enter the lengths of the three sides of the triangle:");
        var sideA = _inputHandler.GetTriangleSide("Enter side A:");
        var sideB = _inputHandler.GetTriangleSide("Enter side B:");
        var sideC = _inputHandler.GetTriangleSide("Enter side C:");

        return [sideA, sideB, sideC];
    }
}