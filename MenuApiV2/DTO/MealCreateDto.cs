using MenuApiV2.Attributes;
using System.ComponentModel.DataAnnotations;
public class MealCreateDto
{

    [Required(ErrorMessage = "Meal name is required.")]
    public string mealName { set; get; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int qty { set; get; }

    [NonNegativePrice]
    public int price { set; get; }

    [Required(ErrorMessage = "TimeStart is required.")]
    public DateTime timeStart { set; get; }

    [Required(ErrorMessage = "TimeEnd is required.")]
    [TimeRange]
    public DateTime timeEnd { set; get; }

    [Required(ErrorMessage = "CookId is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "cookid must be positive.")]
    public int cookId { get; set; }
}

