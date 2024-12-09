namespace Shared.Exceptions;

public class ForbiddenException: Exception
{
    
    public ForbiddenException() : base("acesso proibido ao conteúdo")
    {
    }
    
    public ForbiddenException(string message) : base(message)
    {
    }

    public ForbiddenException(string message, Exception inner) : base(message, inner)
    {
    }
}