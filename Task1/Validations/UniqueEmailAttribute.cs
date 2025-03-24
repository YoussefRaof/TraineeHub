using System.ComponentModel.DataAnnotations;
using Task01.Context;
using Task01.Models;

namespace Task01.Validations
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var _dbContext = validationContext.GetRequiredService<TraineeDB>();
            var trainee = validationContext.ObjectInstance as Trainee;
            var email = value as string;
            if(_dbContext.Trainees.Any(t => t.Email == email && t.Id!=trainee.Id))
                return new ValidationResult("Email Already Exist");

            return ValidationResult.Success;
        }
    }
}
