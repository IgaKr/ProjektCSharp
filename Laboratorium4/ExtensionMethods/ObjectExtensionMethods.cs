namespace Laboratorium4.ExtensionMethods
{
    public static class ObjectExtensionMethods
    {
        public static int ToInt(this object obj)
        {
            return int.Parse(obj.ToString()!);
        }
    }
}
