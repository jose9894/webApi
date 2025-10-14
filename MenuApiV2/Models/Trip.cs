using System;
using System.Collections.Generic;

namespace MenuApiV2.Models;

public partial class Trip
{
    public int TId { get; set; }

    public int TripPay { get; set; }

    public int DcId { get; set; }

    public int OId { get; set; }

    public int TTime { get; set; }

    public virtual DeliveryCyclist Dc { get; set; } = null!;

    public virtual Order OIdNavigation { get; set; } = null!;

    public virtual ICollection<TripDetail> TripDetails { get; set; } = new List<TripDetail>();
}
