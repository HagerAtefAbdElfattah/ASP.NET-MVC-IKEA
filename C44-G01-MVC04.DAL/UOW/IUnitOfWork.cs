using C44_G01_MVC04.DAL.Repositories.DepartmentRepo;
using C44_G01_MVC04.DAL.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.UOW
{
    public interface IUnitOfWork
    {
        public DepartmentRepository DepartmentRepository { get; set; }
        public EmployeeRepository EmployeeRepository { get; set; }

        public int Complete();
    }
}
