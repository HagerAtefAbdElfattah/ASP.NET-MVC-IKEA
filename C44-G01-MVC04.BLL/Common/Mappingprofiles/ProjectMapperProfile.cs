using AutoMapper;
using C44_G01_MVC04.BLL.Dto_s;
using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using C44_G01_MVC04.BLL.Dto_s.EmployeeDto_s;
using C44_G01_MVC04.DAL.Models.Department;
using C44_G01_MVC04.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.BLL.Common.Mappingprofiles
{
    public class ProjectMapperProfile:Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<Employee,EmployeeDto>()
                .ForMember(d => d.DepartmentName,option => option.MapFrom(scr => scr.Department != null ? scr.Department.Name : "N/A")).ReverseMap();
            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(d => d.DepartmentName, option => option.MapFrom(scr => scr.Department != null ? scr.Department.Name : "N/A")).ReverseMap();
            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(des => des.EmployeeType,option =>option.MapFrom(src => src.EmployeeType))
                .ForMember(d => d.DepartmentId, option => option.MapFrom(scr => scr.DepartmentId)).ReverseMap(); ;
            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(d => d.DepartmentId, option => option.MapFrom(scr => scr.DepartmentId)).ReverseMap(); 


            CreateMap<DateTime, DateOnly>().ConvertUsing(src => DateOnly.FromDateTime(src));
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, CreatedDepartmentDto>().ReverseMap();
            CreateMap<DepartmentDetailsDto,Department >().ReverseMap();
            CreateMap<UpdatedDepartmentDto, Department>().ReverseMap();

        }
    }
}
