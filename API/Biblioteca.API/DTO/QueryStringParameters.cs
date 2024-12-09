namespace Biblioteca.API.DTO;

public class QueryStringParameters
{
    // atributo que servirá de indice para ordenação
    public string SortBy { get; set; } = "id";
    
    // define a ordem dos dados, crescente ou decrescente
    public bool IsDecsending { get; set; } = false;
    
    // define uma palavra chave para pesisa
    public string Search { get; set; } = string.Empty;
    
    // número máximo de itens por página
    const int maxPageSize = 100;
    
    // o número da página
    public int PageNumber { get; set; } = 1;
    
    // tamanho padrão da página
    private int _pageSize = 50;
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}