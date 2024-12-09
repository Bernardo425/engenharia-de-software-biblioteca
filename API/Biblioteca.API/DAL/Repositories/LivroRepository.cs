using System.Linq.Expressions;
using Biblioteca.API.DAL.Repositories.Contracts;
using Biblioteca.API.DTO;
using Biblioteca.API.DTO.Livro;
using Biblioteca.API.Helpers;
using Biblioteca.API.Model;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API.DAL.Repositories;

public class LivroRepository: RepositoryBase<Livro>, ILivroRepository
{

    private readonly AppDbContext _context;

    public LivroRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public PagedList<Livro> GetAllPaged(LivroParameters parameters)
    {
        var livro = FindByCondition(BuildWhereClause(parameters)).OrderByField(parameters.SortBy, parameters.IsDecsending);
        return PagedList<Livro>.ToPagedList(livro, parameters.PageNumber, parameters.PageSize); 
    }

    public async Task<Livro?> GetByIdAsync(int id)
    {
        return await FindByCondition(c => c.Id == id).FirstOrDefaultAsync();
    }

    private Expression<Func<Livro, bool>> BuildWhereClause(LivroParameters parameters)
    {
        var predicate = PredicateBuilder.New<Livro>(true);

        if (parameters.Ano is not null)
        {
            predicate = predicate.And(c => c.Ano == parameters.Ano.Value);
        }
            
        if (!string.IsNullOrWhiteSpace(parameters.Search))
        {
            var searchPredicate = PredicateBuilder.New<Livro>(false);
            searchPredicate = searchPredicate.Or(c => c.Titulo.ToLower().Trim().Contains(parameters.Search.ToLower().Trim()));
            searchPredicate = searchPredicate.Or(c => c.Isbn.ToLower().Trim().Contains(parameters.Search.ToLower().Trim()));
            searchPredicate = searchPredicate.Or(c => c.Autor.ToLower().Trim().Contains(parameters.Search.ToLower().Trim()));
            predicate = predicate.And(searchPredicate);
        }
        
        return predicate;
    }
}