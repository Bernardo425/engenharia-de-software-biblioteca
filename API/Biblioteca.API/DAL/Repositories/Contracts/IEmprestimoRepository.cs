using Biblioteca.API.DTO;
using Biblioteca.API.DTO.Emprestimo;
using Biblioteca.API.Model;

namespace Biblioteca.API.DAL.Repositories.Contracts;

public interface IEmprestimoRepository : IRepositoryBase<Emprestimo>
{
    
    PagedList<Emprestimo> GetAllPaged(EmprestimoParameters parameters);
    Task<Emprestimo?> GetByIdAsync(int id);
}