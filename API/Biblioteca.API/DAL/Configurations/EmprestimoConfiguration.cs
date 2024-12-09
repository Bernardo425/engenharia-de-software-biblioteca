using Biblioteca.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.API.DAL.Configurations;

public class EmprestimoConfiguration: IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {
        
        builder.Property(c => c.Estado)
            .HasColumnType("tinyint");
            
    }
}