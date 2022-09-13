using Microsoft.EntityFrameworkCore;

namespace StockAvailableAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Models.Product> products { get; set; }
        public DbSet<Models.TypeOperation> typeOperations { get; set; }
        public DbSet<Models.Box> boxes { get; set; }
        public DbSet<Models.Operation> operations { get; set; }
    }
}
