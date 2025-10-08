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
