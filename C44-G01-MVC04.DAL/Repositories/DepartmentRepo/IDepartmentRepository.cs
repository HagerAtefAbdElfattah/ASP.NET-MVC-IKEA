using C44_G01_MVC04.DAL.Models.Department;
using C44_G01_MVC04.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Repositories.DepartmentRepo
{
    public interface IDepartmentRepository:IGenericeRepository<Department>
    {

        public IEnumerable<Department> GetAll(string? SearchValue);

    }
}
