using System;
using System.Collections.Generic;

namespace MenuApiV2.Models;

public partial class Order
{
    public int OId { get; set; }

    public DateTime ODate { get; set; }

    public int CId { get; set; }

    public virtual Customer CIdNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
