using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class R_Slot
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public int BranchId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool IsActive { get; set; }
}
