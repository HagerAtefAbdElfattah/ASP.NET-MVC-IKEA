using C44_G01_MVC04.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Reposatories.DepartmentRepo
{
    public interface IDepartmentReposatory
    {
        public IEnumerable<Department> GetAll(bool WithTrack=false);
        public Department GetById(int id);
        public int Add(Department department);
        public int Update(Department department);
        public int Delete(int id);
    }
}
