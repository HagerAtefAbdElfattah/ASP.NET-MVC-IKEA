using C44_G01_MVC04.DAL.Models.Department;
using C44_G01_MVC04.DAL.Models.Employees;
using C44_G01_MVC04.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Contexts
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionBuilder): base(optionBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Department> departments { get; set; } 
        public DbSet<Employee> Employees { get; set; }
    }
}
