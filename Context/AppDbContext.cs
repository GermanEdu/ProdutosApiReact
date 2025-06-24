using Microsoft.EntityFrameworkCore;
using ProdutosApiReact.Models;

namespace ProdutosApiReact.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
