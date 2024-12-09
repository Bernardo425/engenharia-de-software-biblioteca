using Biblioteca.API.Model.Enums;

namespace Biblioteca.API.DTO.Emprestimo;

public class EmprestimoUpdateDto
{
    public decimal? Multa { get; set; }
    public EmprestimoEstado? Estado { get; set; }
}