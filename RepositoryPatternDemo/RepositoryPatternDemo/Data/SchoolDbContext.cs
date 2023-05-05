using Microsoft.EntityFrameworkCore;

namespace RepositoryPatternDemo.Data
{
    public class SchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               "Data Source=GDIT019PC\\SQLEXPRESS;Initial Catalog=Test1;Integrated Security=True");
        }

        public DbSet<Student> Students { get; set; }
    }
}
