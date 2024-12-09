using AutoMapper;
using Biblioteca.API.DAL.Repositories.Contracts;
using Biblioteca.API.DTO;
using Biblioteca.API.DTO.Livro;
using Biblioteca.API.Model;
using Biblioteca.API.Service.Contracts;
using Shared.Exceptions;

namespace Biblioteca.API.Service;

public class LivroService: ILivroService
{

    private readonly ILivroRepository _livroRepository;
    private readonly IMapper _mapper;

    public LivroService(ILivroRepository livroRepository, IMapper mapper)
    {
        _livroRepository = livroRepository;
        _mapper = mapper;
    }

    public PagedList<LivroDto> GetAllPaged(LivroParameters parameters)
    {
        var livro = _livroRepository.GetAllPaged(parameters);
        var livroDto = _mapper.Map<PagedList<LivroDto>>(livro);
        return livroDto;
    }
    
    public async Task<LivroDto> GetByIdAsync(int idLivro)
    {
        var livro = await _livroRepository.GetByIdAsync(idLivro);
        if (livro == null) throw new NotFoundException("livro não encontrado");
        return _mapper.Map<LivroDto>(livro);
    }
    
    public async Task<LivroDto> CreateAsync(LivroCreateDto dto)
    {
        var livro = _mapper.Map<Livro>(dto);
        
        livro.CreatedOn = DateTime.Now;
        _livroRepository.Add(livro);
        await _livroRepository.SaveChangesAsync();
        
        return _mapper.Map<LivroDto>(livro);
    }
    
    public async Task<LivroDto> UpdateAsync(int id, LivroUpdateDto dto)
    {
        
        var livro = await _livroRepository.GetByIdAsync(id);
        if (livro == null) throw new NotFoundException("livro não encontrado");

        _mapper.Map(dto, livro);
        _livroRepository.Update(livro);
        await _livroRepository.SaveChangesAsync();

        return _mapper.Map<LivroDto>(livro);
    }

    public async Task DeleteAsync(int id)
    {
        var livro = await _livroRepository.GetByIdAsync(id);
        if (livro == null) throw new NotFoundException("livro não encontrado");
        
        _livroRepository.Remove(livro);
        await _livroRepository.SaveChangesAsync();
    }
}