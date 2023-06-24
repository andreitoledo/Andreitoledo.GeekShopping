using Microsoft.EntityFrameworkCore;

namespace Andreitoledo.GeekShopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) 
            : base(options) { }

        // Adiciona o dbset em products no nosso mapeamento - Andrei
        public DbSet<Product> Products { get; set; }
    }
}
