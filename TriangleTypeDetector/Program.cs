using TriangleTypeDetector.Services;


var uiHandler = new ConsoleUIHandler();
var inputHandler = new ConsoleInputHandler(uiHandler);
var triangleSideProvider = new TriangleSideProvider(inputHandler, uiHandler);
var typeDeterminer = new TypeDetector();
var programFlowHandler = new ProgramFlowHandler(uiHandler, triangleSideProvider, typeDeterminer);

programFlowHandler.Start();
