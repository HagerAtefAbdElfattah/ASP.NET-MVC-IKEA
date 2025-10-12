using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using C44_G01_MVC04.BLL.Services.DepartmentsServices;
using C44_G01_MVC04.PL.ViewModels.DepartmentVms;
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
        //[ValidateAntiForgeryToken]
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

        [HttpGet]
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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();

            var department = departmentServices.GetDepartmentById(id.Value);

            if (department == null)
            {
                return NotFound();
            }

            var viewDepartment = new DepartmentViewModel()
            { 
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
            };

            return View(viewDepartment);
        }

        public IActionResult Edit([FromRoute]int? id, DepartmentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var department = new UpdatedDepartmentDto()
            {
                Id = id.Value,
                Name = model.Name,
                Code = model.Code,
                Description = model.Description,
            };

            try
            {
                if (ModelState.IsValid)
                {
                    int result = departmentServices.UpdateDepartment(department);

                    if (result > 0) return RedirectToAction("Index");
                    else ModelState.AddModelError(string.Empty, "Department Can't be updated");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                if (webHost.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                    return View(department);
                }
                else
                {
                    throw;
                }
            }
            
        }

        [HttpGet]
        public IActionResult Delete([FromRoute]int? id) 
        {
            if (id == null) return BadRequest();

            var department = departmentServices.GetDepartmentById(id.Value);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
           var result = departmentServices.DeleteDepartment(id);
            if (result > 0) { return RedirectToAction("Index"); }
            else
            {
                var department = departmentServices.GetDepartmentById(id);

                if (department == null)
                {
                    return NotFound();
                }
                ModelState.AddModelError(string.Empty, "something went wrong!");
                return View(department);
            }
        }
    }
}
