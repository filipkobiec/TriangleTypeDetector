using TriangleTypeDetector.Enums;
using TriangleTypeDetector.Exceptions;
using TriangleTypeDetector.Interfaces;

namespace TriangleTypeDetector.Services;

public class ProgramFlowHandler : IProgramFlowHandler
{
    private readonly IUIHandler _uiHandler;
    private readonly ITriangleSideProvider _triangleSideProvider;
    private readonly ITypeDetector _typeDetector;

    public ProgramFlowHandler(IUIHandler uiHandler, ITriangleSideProvider triangleSideProvider,
        ITypeDetector typeDetector)
    {
        _uiHandler = uiHandler;
        _triangleSideProvider = triangleSideProvider;
        _typeDetector = typeDetector;
    }

    public void Start()
    {
        try
        {
            var sides = _triangleSideProvider.GetTriangleSides();
            var result = _typeDetector.DetectType(sides);
            DisplayTriangleType(result);
 
        }
        catch (TriangleTypeDetectionException ex)
        {
            _uiHandler.ShowMessage($"An error occurred: {ex.Message}");
        }
    }
    
    private void DisplayTriangleType(TriangleType type)
    {
        var message = type switch
        {
            TriangleType.Equilateral => "The triangle is an Equilateral triangle.",
            TriangleType.Isosceles => "The triangle is an Isosceles triangle.",
            TriangleType.Scalene => "The triangle is a Scalene triangle.",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid triangle type")
        };
        
        _uiHandler.ShowMessage(message);
    }
}