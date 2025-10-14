using System;
using System.Collections.Generic;

namespace MenuApiV2.Models;

public partial class Cook
{
    public int CId { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNr { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool Certificate { get; set; } = false;

    public virtual ICollection<Meal> Meals { get; set; } = new List<Meal>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
