using Microsoft.EntityFrameworkCore;

namespace Livraria.Models.Domain
{
    public class LivrariaDbContext:DbContext
    {
        public LivrariaDbContext(DbContextOptions<LivrariaDbContext>options):base(options) 
        { 
        
        }

        public DbSet<Genero> Genero { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Livro> Livro { get; set; }
    }
}
