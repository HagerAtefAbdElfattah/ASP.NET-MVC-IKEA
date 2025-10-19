using C44_G01_MVC04.BLL.Dto_s;
using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.BLL.Services.DepartmentsServices
{
    public interface IDepartmentServices
    {
        public IEnumerable<DepartmentDto> GetAllDepartments();
        public IEnumerable<DepartmentDto> GetSearchedDepartments(string searchValue);
        public DepartmentDetailsDto GetDepartmentById(int id);
        public int AddDepartment(CreatedDepartmentDto department);
        public int UpdateDepartment(UpdatedDepartmentDto department);  
        public int DeleteDepartment(int id);
    }
}
