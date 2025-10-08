using C44_G01_MVC04.DAL.Contexts;
using C44_G01_MVC04.DAL.Models.Department;
using C44_G01_MVC04.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Repositories.DepartmentRepo
{
    public class DepartmentRepository : GenericRepository<Department> ,IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }
    }
}
