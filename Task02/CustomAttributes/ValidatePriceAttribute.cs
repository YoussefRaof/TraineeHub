using System.ComponentModel.DataAnnotations;

namespace Task02.CustomAttributes
{
    public class ValidatePriceAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var price = value as double?;
            if (price is not null)
            {
                if (price < 200)
                {
                    return new ValidationResult(" Price Must Be Greater Than 200 Dollars");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult(" Price Must Be Greater Than 200 Dollars");

        }
    }
}
