using C44_G01_MVC04.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace C44_G01_MVC04.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices departmentServices;

        public DepartmentController(IDepartmentServices department)
        {
            this.departmentServices = department;
        }

        public IActionResult Index()
        {
            var dept = departmentServices.GetAllDepartments();
            return View(dept);
        }
    }
}
