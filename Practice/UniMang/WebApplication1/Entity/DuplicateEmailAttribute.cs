using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entity
{
    public class DuplicateEmailAttribute():ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string email)
            {
                // Resolve UniMContext from the request's service provider
                var dbContext = validationContext.GetService<UniMContext>();

                if (dbContext != null)
                {
                    bool exists = dbContext.Students.Any(s => s.Email == email);
                    if (exists)
                    {
                        return new ValidationResult(ErrorMessage ?? "Email address is already in use.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}       
