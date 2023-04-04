using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class AtDbContext : DbContext
    {
        public AtDbContext(DbContextOptions<AtDbContext> options) : base(options) 
        {
        }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
    }
}