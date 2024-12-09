using System.ComponentModel.DataAnnotations;

namespace Biblioteca.API.DTO.Livro;

public class LivroCreateDto
{
    [Required]
    public string Titulo { get; set; }
    
    [Required]
    public string Isbn { get; set; }
    
    [Required]
    public string Autor { get; set; }
    
    [Required]
    public int Ano { get; set; }
    
    [Required]
    public int Quantidade { get; set; }
}