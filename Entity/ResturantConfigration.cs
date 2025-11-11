using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class ResturantConfigration
{
    public int Id { get; set; }

    public int ResturantId { get; set; }

    public int OfferId { get; set; }

    public int VenueId { get; set; }

    public string Day { get; set; } = null!;

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public int Slot { get; set; }

    public int Capacity { get; set; }

    public int Interval { get; set; }

    public bool Status { get; set; }
}
