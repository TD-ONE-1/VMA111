using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class Restaurant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public TimeOnly OpeningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<R_Offer> R_Offers { get; set; } = new List<R_Offer>();
}
