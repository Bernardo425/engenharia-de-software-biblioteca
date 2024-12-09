using System.Text.RegularExpressions;

namespace Biblioteca.API.Helpers;

public static class DataCheck
{
    public static bool IsEmail(string email)
    {
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }
}