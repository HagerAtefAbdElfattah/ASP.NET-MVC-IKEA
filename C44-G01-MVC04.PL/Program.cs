using C44_G01_MVC04.BLL.Common.Mappingprofiles;
using C44_G01_MVC04.BLL.Services.DepartmentsServices;
using C44_G01_MVC04.BLL.Services.EmployeesServices;
using C44_G01_MVC04.DAL.Contexts;
using C44_G01_MVC04.DAL.Repositories.DepartmentRepo;
using C44_G01_MVC04.DAL.Repositories.EmployeeRepo;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace C44_G01_MVC04.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext <ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();

            builder.Services.AddAutoMapper(cfg => { }, (typeof(ProjectMapperProfile)));
            var app = builder.Build();

            

            app.UseRouting();

            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();



            #region session-6 video1 
            //////////////// IQueryable<T> /////////////////////////////////

            // Works with remote data sources(like databases via Entity Framework)
            // Deferred execution but query is built as an expression tree
            // LINQ to SQL / Entities
            //The database executes the query
            // Translated to SQL before execution


            ////////////// IEnumerable<T> /////////////////////////////////
            // Works with in-memory collections (like List<T>)
            // Immediate execution
            // LINQ to Objects
            // The client executes the query
            #endregion
        }
    }
}
