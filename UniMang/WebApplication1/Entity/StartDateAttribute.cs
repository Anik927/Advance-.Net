using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entity
{
    public class StartDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime startDate)
            {
                if (startDate < DateTime.Now)
                {
                    return new ValidationResult("Start date cannot be in the past.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
