namespace Shared.Exceptions;

public class BadRequestException: Exception
{
    public BadRequestException() : base("requisição malformada ou inválida")
    {
    }
    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(string message, Exception inner) : base(message, inner)
    {
    }
}