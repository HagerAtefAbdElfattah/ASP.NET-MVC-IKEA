using System.ComponentModel.DataAnnotations;

namespace C44_G01_MVC04.PL.ViewModels.DepartmentVms
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; } 
        public string? Description { get; set; }
    }
}
