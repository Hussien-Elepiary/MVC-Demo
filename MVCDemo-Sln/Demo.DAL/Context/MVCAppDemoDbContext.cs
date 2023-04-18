using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Context
{
    public class MVCAppDemoDbcontext:DbContext
    {
        public MVCAppDemoDbcontext(DbContextOptions<MVCAppDemoDbcontext> options):base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server = .; DataBase = MVCDemo; trusted_Connection=true; MultipleActiveResultSets=True;");

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
