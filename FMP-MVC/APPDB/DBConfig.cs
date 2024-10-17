using FMP_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FMP_MVC.APPDB
{
    public class DBConfig:DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=FMP_MVC_DB;Integrated Security=True");
        }
    }
}
