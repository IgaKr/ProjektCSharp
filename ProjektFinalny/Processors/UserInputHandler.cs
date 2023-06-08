using Laboratorium2.Interfejsy;
using ProjektFinalny.Interfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
[assembly: InternalsVisibleTo("ProjektFinalny.Tests")]

namespace ProjektFinalny.Processors;

internal class UserInputHandler : BaseUserInputHandler, IUserInputHandler
{
    private readonly IUserLogger _userLogger = default!;

    public UserInputHandler(IUserLogger userLogger)
    {
        _userLogger = userLogger;
    }

    public string GetUserInput(string message)
    {
        var result = string.Empty;
        _userLogger.Log(message);
        result = GetInput();
        return result;
    }
}
