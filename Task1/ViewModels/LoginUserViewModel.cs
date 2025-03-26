using System.ComponentModel.DataAnnotations;

namespace Task01.ViewModels
{

    public class LoginUserViewModel
    {

        [Display(Name ="User Name")]
        public string UserName { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
