using System.Linq.Expressions;
using Biblioteca.API.DAL.Repositories.Contracts;
using Biblioteca.API.DTO;
using Biblioteca.API.DTO.Emprestimo;
using Biblioteca.API.Helpers;
using Biblioteca.API.Model;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API.DAL.Repositories;

public class EmprestimoRepository: RepositoryBase<Emprestimo>, IEmprestimoRepository
{

    private readonly AppDbContext _context;

    public EmprestimoRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public PagedList<Emprestimo> GetAllPaged(EmprestimoParameters parameters)
    {
        var livro = FindByCondition(BuildWhereClause(parameters)).OrderByField(parameters.SortBy, parameters.IsDecsending);
        return PagedList<Emprestimo>.ToPagedList(livro, parameters.PageNumber, parameters.PageSize); 
    }

    public async Task<Emprestimo?> GetByIdAsync(int id)
    {
        return await FindByCondition(c => c.Id == id).FirstOrDefaultAsync();
    }

    private Expression<Func<Emprestimo, bool>> BuildWhereClause(EmprestimoParameters parameters)
    {
        var predicate = PredicateBuilder.New<Emprestimo>(true);

        if (parameters.AlunoId is not null)
        {
            predicate = predicate.And(c => c.UserId == parameters.AlunoId.Value);
        }
        
        if (parameters.LivroId is not null)
        {
            predicate = predicate.And(c => c.LivroId == parameters.LivroId.Value);
        }
        
        if (parameters.Estado is not null)
        {
            predicate = predicate.And(c => c.Estado == parameters.Estado.Value);
        }
            
        if (!string.IsNullOrWhiteSpace(parameters.Search))
        {
            var searchPredicate = PredicateBuilder.New<Emprestimo>(false);
           
            predicate = predicate.And(searchPredicate);
        }
        
        return predicate;
    }
}