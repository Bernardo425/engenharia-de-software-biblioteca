using Biblioteca.API.Model.Enums;

namespace Biblioteca.API.DTO.Emprestimo;

public class EmprestimoParameters: QueryStringParameters
{
    public Guid? AlunoId { get; set; }
    public int? LivroId { get; set; }
    public EmprestimoEstado? Estado { get; set; }
}