using System;
using System.Collections.Generic;

namespace MenuApiV2.Models;

public partial class Meal
{
    public int MId { get; set; }

    public string Name { get; set; } = null!;

    public int Qty { get; set; }

    public int Price { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime TimeEnd { get; set; }

    public int CookId { get; set; }

    public virtual Cook Cook { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
