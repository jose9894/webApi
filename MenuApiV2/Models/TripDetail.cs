using System;
using System.Collections.Generic;

namespace MenuApiV2.Models;

public partial class TripDetail
{
    public int TId { get; set; }

    public TimeOnly TimeStamp { get; set; }

    public string TripType { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual Trip TIdNavigation { get; set; } = null!;
}
