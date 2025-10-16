using C44_G01_MVC04.DAL.Models.Employees;
using C44_G01_MVC04.DAL.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace C44_G01_MVC04.PL.ViewModels.EmployeeVms
{
    public class EmployeeViewModel
    {
     
        public int Id { get; set; }
        public string Name { get; set; } = null!;
      
        public int? Age { get; set; }
        
        public string? Address { get; set; }
       
        public decimal Salary { get; set; }
       
        public bool IsActive { get; set; }
       
        public string? Email { get; set; }
       
        public string? PhoneNumber { get; set; }
      
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; } 
    }
}
