using AutoMapper;
using Biblioteca.API.DTO;

namespace Biblioteca.API.Helpers;

public class PagedListConverter<TSource, TDestination> : ITypeConverter<PagedList<TSource>, PagedList<TDestination>>
{
    private readonly IMapper _mapper;

    public PagedListConverter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public PagedList<TDestination> Convert(PagedList<TSource> source, PagedList<TDestination> destination, ResolutionContext context)
    {
        var items = _mapper.Map<List<TDestination>>(source);
        return new PagedList<TDestination>(items, source.TotalCount, source.CurrentPage, source.PageSize);
    }
}