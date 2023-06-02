using Microsoft.EntityFrameworkCore;

namespace StockAppWebApi.Models
{
    public class StockAppContext : DbContext
    {
        public StockAppContext(DbContextOptions<StockAppContext> options)
           : base(options)
        { }

        public DbSet<User> Users { get; set; }


    }
}
