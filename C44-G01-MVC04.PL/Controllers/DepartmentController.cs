using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using C44_G01_MVC04.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace C44_G01_MVC04.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices departmentServices;
        private readonly ILogger<DepartmentController> logger;
        private readonly IWebHostEnvironment webHost;

        public DepartmentController(IDepartmentServices department,ILogger<DepartmentController> logger, IWebHostEnvironment webHost)
        {
            this.departmentServices = department;
            this.logger = logger;
            this.webHost = webHost;
        }

        public IActionResult Index()
        {
            var dept = departmentServices.GetAllDepartments();
            return View(dept);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto dept)
        {
            try 
            { 
                if (ModelState.IsValid)
                {
                int result = departmentServices.AddDepartment(dept);

                if (result > 0) return RedirectToAction("Index");
                else ModelState.AddModelError(string.Empty, "Department Can't be created");
                return View(dept);
                }
                else
                {
                    return View(dept);
                }
            } 
            catch(Exception ex) 
            {
                if (webHost.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                    return View(dept);
                }
                else
                {
                    throw;
                } 
            }
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();
          
            var department = departmentServices.GetDepartmentById(id.Value);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }
    }
}
