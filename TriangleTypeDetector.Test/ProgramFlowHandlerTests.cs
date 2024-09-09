using Moq;
using TriangleTypeDetector.Enums;
using TriangleTypeDetector.Exceptions;
using TriangleTypeDetector.Interfaces;
using TriangleTypeDetector.Services;

namespace TriangleTypeDetector.Test
{
    [TestFixture]
    public class ProgramFlowHandlerTests
    {
        private Mock<IUIHandler> _uiHandlerMock;
        private Mock<ITriangleSideProvider> _triangleSideProviderMock;
        private Mock<ITypeDetector> _typeDetectorMock;
        private ProgramFlowHandler _programFlowHandler;

        [SetUp]
        public void SetUp()
        {
            _uiHandlerMock = new Mock<IUIHandler>();
            _triangleSideProviderMock = new Mock<ITriangleSideProvider>();
            _typeDetectorMock = new Mock<ITypeDetector>();

            _programFlowHandler = new ProgramFlowHandler(
                _uiHandlerMock.Object,
                _triangleSideProviderMock.Object,
                _typeDetectorMock.Object
            );
        }

        [Test]
        public void Start_ValidTriangle_DisplaysCorrectType()
        {
            // Arrange
            int[] sides = [5, 5, 8];
            _triangleSideProviderMock.Setup(tp => tp.GetTriangleSides()).Returns(sides);
            _typeDetectorMock.Setup(td => td.DetectType(sides)).Returns(TriangleType.Isosceles);

            // Act
            _programFlowHandler.Start();

            // Assert
            _uiHandlerMock.Verify(ui => ui.ShowMessage("The triangle is an Isosceles triangle."), Times.Once);
        }

        [Test]
        public void Start_InvalidTriangle_DisplaysErrorMessage()
        {
            // Arrange
            int[] sides = [1, 2, 3];
            _triangleSideProviderMock.Setup(tp => tp.GetTriangleSides()).Returns(sides);
            _typeDetectorMock.Setup(td => td.DetectType(sides)).Throws(new TriangleTypeDetectionException("The provided sides do not form a valid triangle."));

            // Act
            _programFlowHandler.Start();

            // Assert
            _uiHandlerMock.Verify(ui => ui.ShowMessage("An error occurred: The provided sides do not form a valid triangle."), Times.Once);
        }
    }
}
