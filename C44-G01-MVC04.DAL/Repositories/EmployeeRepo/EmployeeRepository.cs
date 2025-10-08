using C44_G01_MVC04.DAL.Contexts;
using C44_G01_MVC04.DAL.Models.Department;
using C44_G01_MVC04.DAL.Models.Employees;
using C44_G01_MVC04.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Repositories.EmployeeRepo
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
