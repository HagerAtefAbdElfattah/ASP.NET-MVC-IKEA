using System.ComponentModel.DataAnnotations;

namespace C44_G01_MVC04.PL.ViewModels.AccountVms
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
