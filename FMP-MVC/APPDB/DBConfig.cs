using FMP_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FMP_MVC.APPDB
{
    public class DBConfig:DbContext
    {
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Customer> customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=FMP_MVC_DB;Integrated Security=True");
        }
    }
}
