using System.Linq.Expressions;

namespace Biblioteca.API.DAL.Repositories.Contracts;


public interface IRepositoryBase<T>
{

    IQueryable<T> FindAll();
    
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    
    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

    void Add(T entity);
    
    void Update(T entity);
    
    void Remove(T entity);
    
    Task SaveChangesAsync();

    
}