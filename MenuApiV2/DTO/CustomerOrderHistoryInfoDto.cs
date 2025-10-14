namespace MenuApiV2.DTO;

public class CustomerOrderHistoryInfoDto
{
    public DateTime date { set; get; }
    public string mealName { set; get; }
    public int qty { set; get; }
    public int unitprice { set; get; }
    public double totalPrice { set; get; }
    public string address { set; get; }

}