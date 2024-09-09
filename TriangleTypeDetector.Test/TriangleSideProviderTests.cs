using Moq;
using TriangleTypeDetector.Interfaces;
using TriangleTypeDetector.Services;

namespace TriangleTypeDetector.Test
{
    [TestFixture]
    public class TriangleSideProviderTests
    {
        private Mock<IInputHandler> _inputHandlerMock;
        private Mock<IUIHandler> _uiHandlerMock;
        private TriangleSideProvider _triangleSideProvider;

        [SetUp]
        public void SetUp()
        {
            _inputHandlerMock = new Mock<IInputHandler>();
            _uiHandlerMock = new Mock<IUIHandler>();
            _triangleSideProvider = new TriangleSideProvider(
                _inputHandlerMock.Object,
                _uiHandlerMock.Object
            );
        }

        [Test]
        public void GetTriangleSides_CallsUIHandlerAndInputHandler()
        {
            // Arrange
            const int a = 5;
            const int b = 10;
            const int c = 15;

            _uiHandlerMock.Setup(ui => ui.ShowMessage("Please enter the lengths of the three sides of the triangle:"));
            _inputHandlerMock.Setup(ih => ih.GetTriangleSide("Enter side A:")).Returns(a);
            _inputHandlerMock.Setup(ih => ih.GetTriangleSide("Enter side B:")).Returns(b);
            _inputHandlerMock.Setup(ih => ih.GetTriangleSide("Enter side C:")).Returns(c);

            // Act
            var result = _triangleSideProvider.GetTriangleSides();

            // Assert
            Assert.That(result, Is.EqualTo(new[] { a, b, c }));
        }
    }
}