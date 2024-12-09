using Biblioteca.API.Model.Enums;

namespace Biblioteca.API.DTO.Emprestimo;

public class EmprestimoDto
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int AlunoId { get; set; }
    public int LivroId { get; set; }
    public decimal Multa { get; set; }
    public DateTime Retirada { get; set; }
    public DateTime Devolucao { get; set; }   
    public EmprestimoEstado Estado { get; set; }
}