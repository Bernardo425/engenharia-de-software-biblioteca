using Biblioteca.API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API.DAL;

public class AppDbContext: IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
    
    public DbSet<Livro> Livro { get; set; }
    public DbSet<Emprestimo> AgregadoFamiliare { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        string adminRoleId = Guid.NewGuid().ToString();
        builder.Entity<IdentityRole>().HasData([
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "funcionario",
                NormalizedName = "FUNCIONARIO"
            },
            new IdentityRole
            {
                Id = adminRoleId,
                Name = "estudante",
                NormalizedName = "ESTUDANTE"
            },
        ]);

        // Criação de um User
        var adminUserId = Guid.NewGuid().ToString();
        var hasher = new PasswordHasher<IdentityUser>();
        var adminUser = new IdentityUser
        {
            Id = adminUserId,
            UserName = "funcionario",
            NormalizedUserName = "FUNCIONARIO",
            Email = "funcionario@gmail.com",
            NormalizedEmail = "FUNCIONARIO@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "SenhaForte123!")
        };

        builder.Entity<IdentityUser>().HasData(adminUser);

        // Associando o User ao Role
        var adminUserRole = new IdentityUserRole<string>
        {
            UserId = adminUserId,
            RoleId = adminRoleId
        };

        builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);
    }
}