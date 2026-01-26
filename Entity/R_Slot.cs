using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class R_Slot
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public int BranchId { get; set; }

    public int? OfferId { get; set; }

    public string Day { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public decimal Duration { get; set; }

    public int Maximum_Capacity { get; set; }

    public bool IsActive { get; set; }

    public TimeOnly? BreakStartTime { get; set; }

    public TimeOnly? BreakEndTime { get; set; }

    public decimal? BreakDuration { get; set; }

    public virtual ICollection<ReservationRequest> ReservationRequests { get; set; } = new List<ReservationRequest>();
}
