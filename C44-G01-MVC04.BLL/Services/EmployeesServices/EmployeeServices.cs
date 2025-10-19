using AutoMapper;
using C44_G01_MVC04.BLL.Dto_s;
using C44_G01_MVC04.BLL.Dto_s.EmployeeDto_s;
using C44_G01_MVC04.BLL.Factories.DepartmentFactory;
using C44_G01_MVC04.DAL.Models.Employees;
using C44_G01_MVC04.DAL.Repositories.DepartmentRepo;
using C44_G01_MVC04.DAL.Repositories.EmployeeRepo;
using C44_G01_MVC04.DAL.UOW;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IEnumerable<EmployeeDto> GetAllEmployee()
        => mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(unitOfWork.EmployeeRepository.GetAll());


        public IEnumerable<EmployeeDto> GetSearchedEmployees(string searchValue)
        => mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(unitOfWork.EmployeeRepository.GetAll(searchValue));

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
        => mapper.Map<Employee, EmployeeDetailsDto>(unitOfWork.EmployeeRepository.GetById(id));

        public int AddEmployee(CreatedEmployeeDto dto)
        {
            var emp = mapper.Map<CreatedEmployeeDto, Employee>(dto);
            emp.CreatedBy = 1;
            emp.CreatedOn = DateTime.Now;
            emp.LastModifiedBy = 1;
            emp.LastModifiedOn = DateTime.Now; 
            unitOfWork.EmployeeRepository.Add(emp);
            return unitOfWork.Complete();
        }

        public int UpdateEmployee(UpdatedEmployeeDto dto)
        {
            var emp = mapper.Map<UpdatedEmployeeDto, Employee>(dto);
            emp.LastModifiedBy = 1;
            emp.LastModifiedOn = DateTime.Now;
            unitOfWork.EmployeeRepository.Update(emp);
            return unitOfWork.Complete();
        }
        public int DeleteEmployee(int id)
        {
            unitOfWork.EmployeeRepository.Delete(id);
            return unitOfWork.Complete();
        }
    }
}
