using C44_G01_MVC04.BLL.Dto_s;
using C44_G01_MVC04.BLL.Dto_s.EmployeeDto_s;
using C44_G01_MVC04.BLL.Factories.DepartmentFactory;
using C44_G01_MVC04.DAL.Repositories.DepartmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.BLL.Services.EmployeesServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IDepartmentRepository _reposatory;
        public EmployeeServices(IDepartmentRepository reposatory)
        {
            _reposatory = reposatory;
        }
        public IEnumerable<EmployeeDto> GetAllEmployee()
        {
            
        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public int AddEmployee(CreatedEmployeeDto dto)
        {
            throw new NotImplementedException();
        }
      
        public int UpdateEmployee(UpdatedEmployeeDto dto)
        {
            throw new NotImplementedException();
        }

        public int DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

    }
}
