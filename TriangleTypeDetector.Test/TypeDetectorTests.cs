using TriangleTypeDetector.Enums;
using TriangleTypeDetector.Exceptions;
using TriangleTypeDetector.Services;

namespace TriangleTypeDetector.Test
{
    [TestFixture]
    public class TypeDetectorTests
    {
        private TypeDetector _typeDetector;

        [SetUp]
        public void SetUp()
        {
            _typeDetector = new TypeDetector();
        }

        [Test]
        public void DetectType_EquilateralTriangle_ReturnsEquilateral()
        {
            // Arrange
            int[] sides = [5, 5, 5];

            // Act
            var result = _typeDetector.DetectType(sides);

            // Assert
            Assert.That(result, Is.EqualTo(TriangleType.Equilateral));
        }

        [Test]
        public void DetectType_IsoscelesTriangle_ReturnsIsosceles()
        {
            // Arrange
            int[] sides = [5, 5, 8];

            // Act
            var result = _typeDetector.DetectType(sides);

            // Assert
            Assert.That(result, Is.EqualTo(TriangleType.Isosceles));
        }

        [Test]
        public void DetectType_ScaleneTriangle_ReturnsScalene()
        {
            // Arrange
            int[] sides = [5, 6, 7];

            // Act
            var result = _typeDetector.DetectType(sides);

            // Assert
            Assert.That(result, Is.EqualTo(TriangleType.Scalene));
        }

        [Test]
        public void DetectType_InvalidTriangle_ThrowsTriangleTypeDetectionException()
        {
            // Arrange
            int[] sides = [1, 2, 3];

            // Act & Assert
            Assert.Throws<TriangleTypeDetectionException>(() => _typeDetector.DetectType(sides));
        }

        [Test]
        public void DetectType_ZeroSide_ThrowsTriangleTypeDetectionException()
        {
            // Arrange
            int[] sides = [0, 5, 7];

            // Act & Assert
            Assert.Throws<TriangleTypeDetectionException>(() => _typeDetector.DetectType(sides));
        }

        [Test]
        public void DetermineType_NegativeSide_TriangleTypeDetectionException()
        {
            // Arrange
            int[] sides = [1, 5, 7];

            // Act & Assert
            Assert.Throws<TriangleTypeDetectionException>(() => _typeDetector.DetectType(sides));
        }
    }
}
