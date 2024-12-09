using AutoMapper;
using Biblioteca.API.DTO;
using Biblioteca.API.DTO.Emprestimo;
using Biblioteca.API.Model;

namespace Biblioteca.API.Helpers.Mappers;

public class EmprestimoProfile: Profile
{
    private const string DateOnlyFormat = "dd-MM-yyyy";
    private const string DateTimeFormat = "dd-MM-yyyy HH:mm:ss";
    
    public EmprestimoProfile()
    {
        CreateMap<Emprestimo, EmprestimoDto>() 
            .ForMember(c=> c.CreatedOn, opt=> opt.MapFrom(src => src.CreatedOn.ToString(DateTimeFormat)));
        
        CreateMap(typeof(PagedList<>), typeof(PagedList<>))
            .ConvertUsing(typeof(PagedListConverter<,>));
        
        CreateMap<EmprestimoCreateDto, Emprestimo>();
        
        CreateMap<EmprestimoUpdateDto, Emprestimo>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
            {
                if (srcMember == null) return false;
                if (srcMember.GetType().IsValueType)
                {
                    var defaultValue = Activator.CreateInstance(srcMember.GetType());
                    return !srcMember.Equals(defaultValue);
                }
                return true;
            }));
    }
}