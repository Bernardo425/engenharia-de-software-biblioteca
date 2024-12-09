using AutoMapper;
using Biblioteca.API.DAL.Repositories.Contracts;
using Biblioteca.API.DTO;
using Biblioteca.API.DTO.Emprestimo;
using Biblioteca.API.Model;
using Biblioteca.API.Service.Contracts;
using Shared.Exceptions;

namespace Biblioteca.API.Service;

public class EmprestimoService: IEmprestimoService
{

    private readonly IEmprestimoRepository _emprestimoRepository;
    private readonly IMapper _mapper;

    public EmprestimoService(IEmprestimoRepository emprestimoRepository, IMapper mapper)
    {
        _emprestimoRepository = emprestimoRepository;
        _mapper = mapper;
    }

    public PagedList<EmprestimoDto> GetAllPaged(EmprestimoParameters parameters)
    {
        var emprestimo = _emprestimoRepository.GetAllPaged(parameters);
        var emprestimoDto = _mapper.Map<PagedList<EmprestimoDto>>(emprestimo);
        return emprestimoDto;
    }
    
    public async Task<EmprestimoDto> GetByIdAsync(int idEmprestimo)
    {
        var emprestimo = await _emprestimoRepository.GetByIdAsync(idEmprestimo);
        if (emprestimo == null) throw new NotFoundException("emprestimo não encontrado");
        return _mapper.Map<EmprestimoDto>(emprestimo);
    }
    
    public async Task<EmprestimoDto> CreateAsync(EmprestimoCreateDto dto)
    {
        var emprestimo = _mapper.Map<Emprestimo>(dto);
        
        _emprestimoRepository.Add(emprestimo);
        await _emprestimoRepository.SaveChangesAsync();
        
        return _mapper.Map<EmprestimoDto>(emprestimo);
    }
    
    public async Task<EmprestimoDto> UpdateAsync(int id, EmprestimoUpdateDto dto)
    {
        
        var emprestimo = await _emprestimoRepository.GetByIdAsync(id);
        if (emprestimo == null) throw new NotFoundException("emprestimo não encontrado");

        _mapper.Map(dto, emprestimo);
        _emprestimoRepository.Update(emprestimo);
        await _emprestimoRepository.SaveChangesAsync();

        return _mapper.Map<EmprestimoDto>(emprestimo);
    }

    public async Task DeleteAsync(int id)
    {
        var emprestimo = await _emprestimoRepository.GetByIdAsync(id);
        if (emprestimo == null) throw new NotFoundException("emprestimo não encontrado");
        
        _emprestimoRepository.Remove(emprestimo);
        await _emprestimoRepository.SaveChangesAsync();
    }
}