using TriangleTypeDetector.Enums;

namespace TriangleTypeDetector.Interfaces;

public interface ITypeDetector
{
    TriangleType DetectType(int[] sides);
}