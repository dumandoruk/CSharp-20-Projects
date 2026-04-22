using Microsoft.EntityFrameworkCore;
using Project6_API.Entities;

namespace Project6_API.Context
{
    public class CurrencyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=Db6Project;Integrated Security=True;TrustServerCertificate=True");
        }

        public DbSet<Currency> Currencies { get; set; }
    }
}
