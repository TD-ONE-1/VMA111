using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class R_Offer
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public string OfferType { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool IsActive { get; set; }

    public virtual Restaurant Restaurant { get; set; } = null!;
}
