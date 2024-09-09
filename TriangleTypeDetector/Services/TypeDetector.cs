using TriangleTypeDetector.Enums;
using TriangleTypeDetector.Exceptions;
using TriangleTypeDetector.Interfaces;

namespace TriangleTypeDetector.Services;

public class TypeDetector : ITypeDetector
{
    public TriangleType DetectType(int[] sides)
    {
        if (sides.Length != 3)
        {
            throw new TriangleTypeDetectionException("Triangle must have exactly three sides.");
        }
        
        if (!IsTriangleCorrect(sides))
        {
            throw new TriangleTypeDetectionException("The provided sides do not form a valid triangle.");
        }
        
        var a = sides[0];
        var b = sides[1];
        var c = sides[2];

        if (a == b && b == c)
        {
            return TriangleType.Equilateral;
        }
        
        if (a == b || b == c || a == c)
        {
            return TriangleType.Isosceles;
        }
        
        return TriangleType.Scalene;
    }

    private static bool IsTriangleCorrect(int[] sides)
    {
        var a = sides[0];
        var b = sides[1];
        var c = sides[2];

        return a > 0 && b > 0 && c > 0
               && a + b > c
               && a + c > b
               && b + c > a;
    }
}