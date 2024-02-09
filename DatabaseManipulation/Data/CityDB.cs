using Microsoft.EntityFrameworkCore;

namespace a
{
    public class CityDB:DbContext
    {
        public DbSet<City> cities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite("Data Source=City.db");// Data Source=path to the database file
        }
    }
}