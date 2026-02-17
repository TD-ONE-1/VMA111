using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class EidReservation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int NoOfMembers { get; set; }

    public int BookingTypeId { get; set; }

    public int SlotId { get; set; }

    public int MealTypeId { get; set; }

    public bool SpecialRequest { get; set; }

    public virtual R_BookingType BookingType { get; set; } = null!;

    public virtual MealType MealType { get; set; } = null!;

    public virtual R_Slot Slot { get; set; } = null!;
}
