namespace ProjektFinalny.Processors;

public abstract class BaseUserInputHandler
{
    public virtual string GetInput()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}
