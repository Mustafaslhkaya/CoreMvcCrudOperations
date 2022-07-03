using CoreMvcCrudOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMvcCrudOperations.DataAccess
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-8SOBN3H\\SQLEXPRESS;database=MvcPersonelCrud;integrated security=true;");


        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Personel> Personels { get; set; }
    }
}
