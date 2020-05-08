namespace ProductService.Database
{
    using Microsoft.EntityFrameworkCore;
    using ProductService.Database.Entities;

    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP\SQLEXPRESS; initial catalog=products; 
                                         persist security info=True; Integrated Security=SSPI;");
        }
    }
}
