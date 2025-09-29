using C44_G01_MVC04.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s
{
    public class DepartmentDetailsDto
    {
        //constructor mapping
        public DepartmentDetailsDto(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Code = department.Code;
            Description = department.Description;
            CreatedBy = department.CreatedBy;
            CreatedOn = DateOnly.FromDateTime(department.CreatedOn);
            LastModifiedBy = department.LastModifiedBy;
            LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly CreatedOn { get; set; } 
        public int LastModifiedBy { get; set; }
        public DateOnly LastModifiedOn { get; set; }
    }
}
