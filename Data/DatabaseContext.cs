using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(connectionString: "Password=reallyStrongPwd123;Persist Security Info=True;User ID=SA; Initial Catalog = DatabaseContext; Data Source=localhost");
        }

        public DbSet<Models.User> Users { get; set; }

    }
}