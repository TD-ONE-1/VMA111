using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class R_Branch
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int Capacity { get; set; }

    public bool IsActive { get; set; }
}
