using Biblioteca.API.Model.Enums;

namespace Biblioteca.API.DTO.Livro;

public class LivroUpdateDto
{
        public string? Titulo { get; set; }
        public string? Isbn { get; set; }
        public string? Autor { get; set; }
        public int? Ano { get; set; }
        public int? Quantidade { get; set; }
        public LivroEstado? Estado { get; set; }
}