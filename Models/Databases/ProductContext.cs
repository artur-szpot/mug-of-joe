using CoffeeMugWebApi.Models.DataTypes;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMugWebApi.Models.Databases
{
    /*
     * Provides connection to a Products database using Entity Framework.
     */
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
