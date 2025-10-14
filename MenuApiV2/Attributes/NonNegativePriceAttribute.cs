using System.ComponentModel.DataAnnotations;

namespace MenuApiV2.Attributes
{
    public class NonNegativePriceAttribute : ValidationAttribute
    {
        public NonNegativePriceAttribute()
            : base("Price cannot be negative.") { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int price && price < 0)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
