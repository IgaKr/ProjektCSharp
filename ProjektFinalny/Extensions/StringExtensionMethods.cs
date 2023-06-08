namespace ProjektFinalny.Extensions;

public static class StringExtensionMethods
{
    public static int ToInt(this string stringToConvert)
    {
        return int.Parse(stringToConvert);
    }
}
