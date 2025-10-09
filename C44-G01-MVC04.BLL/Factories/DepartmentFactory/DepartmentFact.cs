using C44_G01_MVC04.BLL.Dto_s;
using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using C44_G01_MVC04.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.BLL.Factories.DepartmentFactory
{
    public static class DepartmentFact
    {
        //public static DepartmentDto ToDepartmentDeto(this Department department)
        //{
        //    return new DepartmentDto
        //    {
        //        Id = department.Id,
        //        Name = department.Name,
        //        Code = department.Code,
        //        Description = department.Description
        //    };
        //}

        //public static DepartmentDetailsDto ToEntity(this Department department)
        //{
        //    return new DepartmentDetailsDto(department);
        //}

        //public static Department ToDepartment (this CreatedDepartmentDto department)
        //{
        //    return new Department() 
        //    {
        //        Name = department.Name,
        //        Code = department.Code,
        //        Description = department.Description,
        //        CreatedBy = 1,
        //        CreatedOn = DateTime.Now,
        //        LastModifiedBy = 1,
        //        LastModifiedOn = DateTime.Now
        //    };
        //}

        //public static Department FromUpdatedDepartment(this UpdatedDepartmentDto department)
        //{
        //    return new Department()
        //    {
        //        Id = department.Id,
        //        Name = department.Name,
        //        Code = department.Code,
        //        Description = department.Description,
        //        LastModifiedBy = 1,
        //        LastModifiedOn = DateTime.Now
        //    };
        //}
    }
}
