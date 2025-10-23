using System.ComponentModel.DataAnnotations;

namespace C44_G01_MVC04.PL.ViewModels.AccountVms
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
