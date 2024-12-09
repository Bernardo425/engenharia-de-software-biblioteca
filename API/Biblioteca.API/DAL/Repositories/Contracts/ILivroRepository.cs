using Biblioteca.API.DTO;
using Biblioteca.API.DTO.Livro;
using Biblioteca.API.Model;

namespace Biblioteca.API.DAL.Repositories.Contracts;


public interface ILivroRepository : IRepositoryBase<Livro>
{
    
    PagedList<Livro> GetAllPaged(LivroParameters parameters);
    
    Task<Livro?> GetByIdAsync(int id);
}