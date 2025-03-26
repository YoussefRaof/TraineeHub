using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;

namespace Task01.ViewModels
{
    [Keyless]
    public class RegisterUserViewModel
    {

        [Display(Name ="User Name")]
        public string UserName { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
        public string Address { get; set; } = null!;

    }
}
