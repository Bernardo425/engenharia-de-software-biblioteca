using Biblioteca.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.API.DAL.Configurations;

public class LivroConfiguration: IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        
        builder.Property(c => c.Estado)
            .HasColumnType("tinyint");
        
    }
}