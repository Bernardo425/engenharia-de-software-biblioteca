using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Biblioteca.API.Model.Enums;

namespace Biblioteca.API.Model;

[Table("Livros")]
public class Livro
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    public string Titulo { get; set; }
    public string Isbn { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }
    
    public int Quantidade { get; set; }

    public LivroEstado Estado { get; set; } = LivroEstado.Indiponivel;

    
    // Lista de todos os emprestimos
    public IEnumerable<Emprestimo> Emprestimos { get; set; }
    
}