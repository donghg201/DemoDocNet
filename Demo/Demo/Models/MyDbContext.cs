using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-8H3JR7M;Initial Catalog=Demo;Integrated Security=True");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bussiness> Bussiness { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccTransaction> AccTransactions { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
