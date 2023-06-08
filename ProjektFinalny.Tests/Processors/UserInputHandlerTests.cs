using Laboratorium2.Enums;
using Laboratorium2.Interfejsy;
using Moq;
using ProjektFinalny.Processors;

namespace ProjektFinalny.Tests.Processors;

[TestClass]
public class UserInputHandlerTests
{
    private Mock<IUserLogger> _userLoggerMock = default!;
    private Mock<BaseUserInputHandler> _baseUserInputHandlerMock = default!;

    [TestInitialize]
    public void Initialize()
    {
        _userLoggerMock = new Mock<IUserLogger>();
        _baseUserInputHandlerMock = new Mock<BaseUserInputHandler>();
    }

    [TestMethod]
    public void GetUserInput_ShouldDisplaySepcifiedMessage()
    {
        _userLoggerMock.Setup(_ => _.Log(It.IsAny<string>(), It.IsAny<RodzajLoga>()));
        _baseUserInputHandlerMock.Setup(_ => _.GetInput())
            .Returns("TEST");
        var userInputHandler = new UserInputHandler(_userLoggerMock.Object);
        var message = "Test message";
        var result = userInputHandler.GetUserInput(message);

        _userLoggerMock.Verify(_ => _.Log(message, It.IsAny<RodzajLoga>()), Times.Once);
    }
}
