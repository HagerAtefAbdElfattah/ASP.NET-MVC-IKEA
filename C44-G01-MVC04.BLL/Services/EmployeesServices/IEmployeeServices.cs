using C44_G01_MVC04.BLL.Dto_s;
using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using C44_G01_MVC04.BLL.Dto_s.EmployeeDto_s;
using C44_G01_MVC04.BLL.Factories.EmployeeFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.BLL.Services.EmployeesServices
{
    public interface IEmployeeServices
    {
        public IEnumerable<EmployeeDto> GetAllEmployee();
        public IEnumerable<EmployeeDto> GetSearchedEmployees(string searchValue);
        public EmployeeDetailsDto GetEmployeeById(int id);
        public int AddEmployee(CreatedEmployeeDto dto);
        public int UpdateEmployee(UpdatedEmployeeDto dto);
        public int DeleteEmployee(int id);
    }
}
