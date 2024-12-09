using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Biblioteca.API.Model.Enums;

namespace Biblioteca.API.Model;

[Table("Emprestimos")]
public class Emprestimo
{

    [Key]
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    public User Aluno { get; set; }
    public Guid UserId { get; set; }
    
    public Livro Livro { get; set; }
    public int LivroId { get; set; }
    
    public decimal Multa { get; set; }
    public DateTime? Retirada { get; set; } = DateTime.Now;
    public DateTime? Devolucao { get; set; }
    public EmprestimoEstado Estado { get; set; } = EmprestimoEstado.Pendente;
}