using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class R_BookingType
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public int BranchId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }
}
