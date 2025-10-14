using System.ComponentModel.DataAnnotations;
namespace MenuApiV2.Attributes
{
    public class TimeRangeAttribute : ValidationAttribute
    {
        public TimeRangeAttribute() 
            : base("TimeEnd must be later than TimeStart.") { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Hent hele DTO'en
            var meal = validationContext.ObjectInstance as MealCreateDto;
            if (meal == null)
                return ValidationResult.Success; // Hvis ikke en MealCreateDto, spring validering over

            // Tjek at TimeEnd > TimeStart
            if (meal.timeEnd <= meal.timeStart)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}