using Biblioteca.API.DTO;

namespace Biblioteca.API.Service.Contracts;


public interface IServiceBase<T1, T2, T3, T4>
    where T1 : class 
    where T3 : class
    where T4 : class
{
   
    public PagedList<T1> GetAllPaged(T2 parameters);

   
    Task<T1> GetByIdAsync(int id);

   
    Task<T1> CreateAsync(T3 request);

 
    Task<T1> UpdateAsync(int id, T4 request);

   
    Task DeleteAsync(int id);
}
