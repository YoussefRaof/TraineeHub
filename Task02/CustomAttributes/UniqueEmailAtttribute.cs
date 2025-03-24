using System.ComponentModel.DataAnnotations;
using Task02.Context;
using Task02.Models;

namespace Task02.CustomAttributes
{
    public class UniqueEmailAtttribute :ValidationAttribute
    {
        public UniqueEmailAtttribute()
        {
            
        }
      
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
             var _dbContext = validationContext.GetService<Lab8Task02DbContext>();
            var customer = validationContext.ObjectInstance as Customer;
            if (_dbContext.Customers.Any(C => C.Email == value as string && customer.Id  != C.Id))
                return new ValidationResult("Email Already Exist");
            return ValidationResult.Success;;
        }
    }
}
