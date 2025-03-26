using Microsoft.AspNetCore.Identity;

namespace Task01.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
