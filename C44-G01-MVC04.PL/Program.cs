using C44_G01_MVC04.BLL.Services;
using C44_G01_MVC04.DAL.Contexts;
using C44_G01_MVC04.DAL.Reposatories.DepartmentRepo;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddScoped<IDepartmentReposatory, DepartmentReposatory>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            var app = builder.Build();

            

            app.UseRouting();

            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
