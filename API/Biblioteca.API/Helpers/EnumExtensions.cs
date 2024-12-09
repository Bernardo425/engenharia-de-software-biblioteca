namespace Biblioteca.API.Helpers;

public static class EnumExtensions
{
    public static bool IsDefined<T>(this T value) where T : Enum
    {
        return Enum.IsDefined(typeof(T), value);
    }
}

