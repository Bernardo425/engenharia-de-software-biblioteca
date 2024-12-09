namespace Biblioteca.API.Model.Enums;

public enum EmprestimoEstado
{
    // aguardando a devolução do livro para ser emprestado
    Pendente = 0,
    
    // O livro está com o estudante
    Activo,
    
    // O livro foi devolvido
    Devolvido
    
}