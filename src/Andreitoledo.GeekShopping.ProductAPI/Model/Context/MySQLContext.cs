using Microsoft.EntityFrameworkCore;

namespace Andreitoledo.GeekShopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) 
            : base(options) { }
    }
}
