namespace Laboratorium2.Klasy
{
    internal static class StringExtensionsMethod
    {
        public static decimal ParseDecimal(this string str)
        {
            decimal.TryParse(str, out decimal result);
            return result;
        }
    }
}
