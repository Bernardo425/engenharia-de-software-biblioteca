using Biblioteca.API.DTO.Livro;

namespace Biblioteca.API.Service.Contracts;

public interface ILivroService: IServiceBase<LivroDto, LivroParameters, LivroCreateDto, LivroUpdateDto>
{
  
}