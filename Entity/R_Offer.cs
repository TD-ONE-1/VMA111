using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class R_Offer
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public int BranchId { get; set; }

    public string Offer { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool IsActive { get; set; }

    public virtual R_Branch Branch { get; set; } = null!;

    public virtual ICollection<R_Menu> R_Menus { get; set; } = new List<R_Menu>();

    public virtual ICollection<ReservationRequest> ReservationRequests { get; set; } = new List<ReservationRequest>();

    public virtual Restaurant Restaurant { get; set; } = null!;
}
