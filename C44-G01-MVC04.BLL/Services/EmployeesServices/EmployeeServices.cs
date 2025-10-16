using AutoMapper;
using C44_G01_MVC04.BLL.Dto_s;
using C44_G01_MVC04.BLL.Dto_s.EmployeeDto_s;
using C44_G01_MVC04.BLL.Factories.DepartmentFactory;
using C44_G01_MVC04.DAL.Models.Employees;
using C44_G01_MVC04.DAL.Repositories.DepartmentRepo;
using C44_G01_MVC04.DAL.Repositories.EmployeeRepo;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.BLL.Services.EmployeesServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _reposatory;
        private readonly IMapper mapper;

        public EmployeeServices(IEmployeeRepository reposatory,IMapper mapper)
        {
            _reposatory = reposatory;
            this.mapper = mapper;
        }
        public IEnumerable<EmployeeDto> GetAllEmployee()
        => mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(_reposatory.GetAll());

        //break point here to see the generated SQL query
        //{
        //    //var result = _reposatory.GetEnumerable().Where(e => e.IsActive == true)
        //    //                                         .Select(e => new EmployeeDto
        //    //                                          {
        //    //                                              Id = e.Id,
        //    //                                              Name = e.Name,
        //    //                                              Age = e.Age,
        //    //                                              Salary = e.Salary,
        //    //                                              IsActive = e.IsActive,
        //    //                                              Email = e.Email,
        //    //                                          });
        //    //return result.ToList();

        //    var result = _reposatory.GetQueryable().Where(e => e.IsActive == true)
        //                                            .Select(e => new EmployeeDto
        //                                            {
        //                                                Id = e.Id,
        //                                                Name = e.Name,
        //                                                Age = e.Age,
        //                                                Salary = e.Salary,
        //                                                IsActive = e.IsActive,
        //                                                Email = e.Email,
        //                                            });
        //    return result.ToList();
        //}


        public EmployeeDetailsDto GetEmployeeById(int id)
        => mapper.Map<Employee, EmployeeDetailsDto>(_reposatory.GetById(id));

        public int AddEmployee(CreatedEmployeeDto dto)
        {
            var emp = mapper.Map<CreatedEmployeeDto, Employee>(dto);
            emp.CreatedBy = 1;
            emp.CreatedOn = DateTime.Now;
            emp.LastModifiedBy = 1;
            emp.LastModifiedOn = DateTime.Now; 
            return _reposatory.Add(emp);

        }

        public int UpdateEmployee(UpdatedEmployeeDto dto)
        {
            var emp = mapper.Map<UpdatedEmployeeDto, Employee>(dto);
            emp.LastModifiedBy = 1;
            emp.LastModifiedOn = DateTime.Now;
            return _reposatory.Update(emp);
        }
        public int DeleteEmployee(int id)
        => _reposatory.Delete(id);

    }
}
