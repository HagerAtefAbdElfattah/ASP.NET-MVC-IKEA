using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using C44_G01_MVC04.BLL.Dto_s.EmployeeDto_s;
using C44_G01_MVC04.BLL.Services.DepartmentsServices;
using C44_G01_MVC04.BLL.Services.EmployeesServices;
using C44_G01_MVC04.PL.ViewModels.DepartmentVms;
using Microsoft.AspNetCore;
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

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var employee = employeeServices.GetEmployeeById(id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();

            var employee = employeeServices.GetEmployeeById(id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            var viewEmployee = new UpdatedEmployeeDto()
            {
              Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
            };

            return View(viewEmployee);
        }

        [ HttpPost]
        public IActionResult Edit([FromRoute] int? id, UpdatedEmployeeDto model)
        {
            if (!ModelState.IsValid) return View(model);
            var emp = new UpdatedEmployeeDto()
            {
               Id = id.Value,
                Name = model.Name,
                Age = model.Age,
                Address = model.Address,
                Salary = model.Salary,
                IsActive = model.IsActive,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                HiringDate = model.HiringDate,
            };

            try
            {
                if (ModelState.IsValid)
                {
                    int result = employeeServices.UpdateEmployee(emp);

                    if (result > 0) return RedirectToAction("Index");
                    else ModelState.AddModelError(string.Empty, "Employee Can't be updated");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                    return View(emp);
                }
                else
                {
                    throw;
                }
            }

        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int? id)
        {
            if (id == null) return BadRequest();

            var employee = employeeServices.GetEmployeeById(id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = employeeServices.DeleteEmployee(id);
            if (result > 0) { return RedirectToAction("Index"); }
            else
            {
                var employee = employeeServices.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }
                ModelState.AddModelError(string.Empty, "something went wrong!");
                return View(employee);
            }
        }
    }
}
