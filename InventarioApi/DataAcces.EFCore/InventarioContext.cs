using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options) 
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStates> ProductStates { get;set; }
    }
}
