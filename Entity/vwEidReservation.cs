using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class vwEidReservation
{
    public int id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int SlotId { get; set; }

    public string? Slot { get; set; }

    public int BookingTypeId { get; set; }

    public string BookingType { get; set; } = null!;

    public int NoOfMembers { get; set; }

    public bool SpecialRequest { get; set; }
}
