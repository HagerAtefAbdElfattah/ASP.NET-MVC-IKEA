using C44_G01_MVC04.DAL.Contexts;
using C44_G01_MVC04.DAL.Repositories.DepartmentRepo;
using C44_G01_MVC04.DAL.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            DepartmentRepository = new DepartmentRepository(context);
            EmployeeRepository = new EmployeeRepository(context);
        }

        public DepartmentRepository DepartmentRepository { get; set ; }
        public EmployeeRepository EmployeeRepository { get ; set ; }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}
