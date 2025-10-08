using C44_G01_MVC04.BLL.Dto_s.EmployeeDto_s;
using C44_G01_MVC04.BLL.Services.EmployeesServices;
using Microsoft.AspNetCore.Mvc;

namespace C44_G01_MVC04.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        private readonly ILogger<EmployeeController> logger;
        private readonly IWebHostEnvironment environment;

        public EmployeeController(IEmployeeServices employeeServices,ILogger<EmployeeController> logger,IWebHostEnvironment environment)
        {
            this.employeeServices = employeeServices;
            this.logger = logger;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var employees = employeeServices.GetAllEmployee();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        
        public IActionResult Create(CreatedEmployeeDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int result = employeeServices.AddEmployee(dto);

                    if (result > 0) return RedirectToAction("Index");
                    else ModelState.AddModelError(string.Empty, "Employee Can't be created");
                    return View(dto);
                }
                else
                {
                    return View(dto);
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                    return View(dto);
                }
                else
                {
                    throw;
                }
            }
        }

    }
}
