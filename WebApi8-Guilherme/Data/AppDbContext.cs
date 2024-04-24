using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using WebApi8_Guilherme.Models;

namespace WebApi8_Guilherme.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AutorModel> Autor { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
    }
}
