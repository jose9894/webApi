using System;
using System.Collections.Generic;

namespace MenuApiV2.Models;

public partial class Customer
{
    public int CId { get; set; }

    public string PhoneNr { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PaymentOpt { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
