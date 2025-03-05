using CrudLivros.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudLivros.Data;

public class AppDbContext : DbContext
{
    public DbSet<AutorModel> Autor { get; set; }
    public DbSet<LivroModel> Livro { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}