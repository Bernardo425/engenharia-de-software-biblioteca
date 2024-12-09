namespace Shared.Exceptions;

public class UnauthorizedException: Exception
{
    
    public UnauthorizedException() : base("conteudo não encontrado")
    {
    }
    
    public UnauthorizedException(string message) : base(message)
    {
    }

    public UnauthorizedException(string message, Exception inner) : base(message, inner)
    {
    }
}