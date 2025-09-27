using C44_G01_MVC04.DAL.Contexts;
using C44_G01_MVC04.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Reposatories.DepartmentRepo
{
    public class DepartmentReposatory:IDepartmentReposatory
    {
        private readonly ApplicationDbContext _context;
        public DepartmentReposatory(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> GetAll(bool withTrack=false)
        {
            if (withTrack)
                return _context.departments.ToList();
            else
                return _context.departments.AsNoTracking().ToList(); 
        }

        public Department GetById(int id)
        {
            var department =_context.departments.Find(id);
            return department;
        }

        public int Add(Department department)
        {
            _context.departments.Add(department);
            return _context.SaveChanges();
        }

        public int Update(Department department)
        {
            _context.departments.Update(department);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var department = _context.departments.Find(id);
            _context.departments.Remove(department);
            return _context.SaveChanges();
        }
    }
}
