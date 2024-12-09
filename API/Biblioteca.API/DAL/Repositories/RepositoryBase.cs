using System.Data.Entity;
using System.Linq.Expressions;
using Biblioteca.API.DAL.Repositories.Contracts;

namespace Biblioteca.API.DAL.Repositories;


public abstract class RepositoryBase<T> : IRepositoryBase<T> 
    where T : class
{

    private readonly AppDbContext _appDbContext;
    
    protected RepositoryBase(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<T> FindAll()
        => _appDbContext.Set<T>().AsNoTracking();
    
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) 
        => _appDbContext.Set<T>().Where(expression).AsNoTracking();

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression) 
        => await _appDbContext.Set<T>().AnyAsync(expression);
    
    public void Add(T entity) 
        => _appDbContext.Set<T>().Add(entity);

    public void Update(T entity) 
        => _appDbContext.Set<T>().Update(entity);

    public void Remove(T entity) 
        => _appDbContext.Remove(entity);

    public async Task SaveChangesAsync() 
        => await _appDbContext.SaveChangesAsync();
    
}
