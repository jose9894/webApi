using System;
using System.Collections.Generic;

namespace MenuApiV2.Models;

public partial class Rating
{
    public int RId { get; set; }

    public int CId { get; set; }

    public int? CookId { get; set; }

    public int? DcId { get; set; }

    public int OId { get; set; }

    public int? CStars { get; set; }

    public int? DcStars { get; set; }

    public virtual Customer CIdNavigation { get; set; } = null!;

    public virtual Cook? Cook { get; set; }

    public virtual DeliveryCyclist? Dc { get; set; }

    public virtual Order OIdNavigation { get; set; } = null!;
}
