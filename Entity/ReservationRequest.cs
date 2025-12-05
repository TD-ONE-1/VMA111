using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class ReservationRequest
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ReservationType { get; set; }

    public DateTime ReservationDate { get; set; }

    public int RestaurantId { get; set; }

    public int BranchId { get; set; }

    public int OfferId { get; set; }

    public int BookingTypeId { get; set; }

    public int SlotId { get; set; }

    public int Members { get; set; }

    public string Remarks { get; set; } = null!;

    public bool Status { get; set; }

    public virtual R_BookingType BookingType { get; set; } = null!;

    public virtual R_Branch Branch { get; set; } = null!;

    public virtual R_Offer Offer { get; set; } = null!;

    public virtual R_Slot Slot { get; set; } = null!;
}
