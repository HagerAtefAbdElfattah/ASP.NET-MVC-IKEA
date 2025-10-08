using C44_G01_MVC04.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Models.Employees
{
    public class Employee : BaseEntity
    {
        public String Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } 
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; } 
        public EmployeeType EmployeeType { get; set; }
        public Gender Gender { get; set; }
    }
}
