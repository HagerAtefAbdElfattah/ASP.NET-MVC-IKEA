using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using C44_G01_MVC04.BLL.Dto_s.EmployeeDto_s;
using C44_G01_MVC04.BLL.Services.DepartmentsServices;
using C44_G01_MVC04.BLL.Services.EmployeesServices;
using C44_G01_MVC04.PL.ViewModels.DepartmentVms;
using C44_G01_MVC04.PL.ViewModels.EmployeeVms;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace C44_G01_MVC04.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        private readonly ILogger<EmployeeController> logger;
        private readonly IWebHostEnvironment environment;
        //private readonly IDepartmentServices departmentServices;

        public EmployeeController(IEmployeeServices employeeServices,ILogger<EmployeeController> logger,IWebHostEnvironment environment)
        {
            this.employeeServices = employeeServices;
            this.logger = logger;
            this.environment = environment;
            //this.departmentServices = departmentServices;
        }

        public IActionResult Index(string? searchValue)
        {
            if (searchValue == null)
                return View(employeeServices.GetAllEmployee());
            else
            ;
            return View(employeeServices.GetSearchedEmployees(searchValue));
        }

        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["Departments"] = departmentServices.GetAllDepartments();
            return View();
        }
       

        [HttpPost]
        
        public IActionResult Create(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CreatedEmployeeDto employee = new CreatedEmployeeDto()
                    {
                        
                        Name = model.Name,
                        Age = model.Age,
                        Address = model.Address,
                        Salary = model.Salary,
                        IsActive = model.IsActive,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        HiringDate = model.HiringDate,
                        DepartmentId= model.DepartmentId,
                    };
                    int result = employeeServices.AddEmployee(employee);

                    if (result > 0) return RedirectToAction("Index");
                    else ModelState.AddModelError(string.Empty, "Employee Can't be created");
                    return View(model);
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                    return View(model);
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

            var viewEmployee = new EmployeeViewModel()
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
                DepartmentName = employee.DepartmentName,
            };

            return View(viewEmployee);
        }

        [ HttpPost]
        public IActionResult Edit([FromRoute] int? id,EmployeeViewModel  model)
        {
            if (!ModelState.IsValid) return View(model);
            var employee = new UpdatedEmployeeDto()
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
                DepartmentId = model.DepartmentId,
            };

            try
            {
                if (ModelState.IsValid)
                {
                    int result = employeeServices.UpdateEmployee(employee);

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
                    return View(employee);
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
