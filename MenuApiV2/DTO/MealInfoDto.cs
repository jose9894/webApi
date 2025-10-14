namespace MenuApiV2.DTO;

public class MealInfoDto
{
    public string mealName { set; get; }
    public int qty { set; get; }
    public int price { set; get; }
    public DateTime timeStart{ set; get; }
    public DateTime timeEnd{ set; get; }

}