using Microsoft.AspNetCore.Identity;

namespace Biblioteca.API.Model;

public class User: IdentityUser
{
    public IEnumerable<Emprestimo> Emprestimos { get; set; }
}