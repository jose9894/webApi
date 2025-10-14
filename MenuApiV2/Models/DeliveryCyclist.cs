using System;
using System.Collections.Generic;

namespace MenuApiV2.Models;

public partial class DeliveryCyclist
{
    public int DcId { get; set; }

    public string PhoneNr { get; set; } = null!;

    public string BikeType { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
