using System.Linq.Expressions;

namespace Biblioteca.API.Helpers;

// métodos de extensão para a interface IQueryable
public static class QueryableExtensions
{
    public static IQueryable<T> OrderByField<T>(this IQueryable<T> source, string chave, bool descending)
    {
       
        var propriedades = chave.Split('.');

        var entityType = typeof(T);
        var parameter = Expression.Parameter(entityType, "p");

        Expression propertyAccess = parameter;

        try
        {
            
            foreach (var propriedade in propriedades)
            {
                
                var nomePropriedade = propriedade.Length > 0
                    ? char.ToUpper(propriedade[0]) + propriedade.Substring(1)
                    : propriedade;

                var property = propertyAccess.Type.GetProperty(nomePropriedade);
                if (property == null)
                {
                    
                    throw new ArgumentException($"Propriedade '{nomePropriedade}' não encontrada.");
                }

                propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
            }
        }
        catch
        {
            
            var fallbackProperty = entityType.GetProperty("Id");
            if (fallbackProperty == null)
            {
                throw new ArgumentException($"Propriedade '{chave}' não encontrada e o fallback 'Id' não está disponível no tipo '{entityType.Name}'.");
            }

            
            propertyAccess = Expression.MakeMemberAccess(parameter, fallbackProperty);
        }

        
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);

        
        var methodName = descending ? "OrderByDescending" : "OrderBy";
        var resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { entityType, propertyAccess.Type },
            source.Expression, Expression.Quote(orderByExpression));

        // Retorna o IQueryable ordenado
        return source.Provider.CreateQuery<T>(resultExpression);
    }


}