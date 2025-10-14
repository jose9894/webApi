using System;
using System.Collections.Generic;

namespace MenuApiV2.Models;

public partial class OrderDetail
{
    public int OId { get; set; }

    public int MId { get; set; }

    public int Qty { get; set; }

    public virtual Meal MIdNavigation { get; set; } = null!;

    public virtual Order OIdNavigation { get; set; } = null!;
}
