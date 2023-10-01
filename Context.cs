using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _005_EF
{
    internal class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "OneToOneTest",
                IntegratedSecurity = true,
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(builder.ConnectionString);

        }

    }
}
