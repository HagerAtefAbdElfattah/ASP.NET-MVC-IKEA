using C44_G01_MVC04.DAL.Models.Employees;
using C44_G01_MVC04.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Repositories.EmployeeRepo
{
    public interface IEmployeeRepository:IGenericeRepository<Employee>
    {
    }
}
