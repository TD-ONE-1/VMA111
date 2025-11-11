using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class ReservationMaster
{
    public int Id { get; set; }

    public int ResturantId { get; set; }

    public int OfferId { get; set; }

    public int VenueId { get; set; }

    public int Slot { get; set; }

    public int TotalCapacity { get; set; }

    public int CurrentCapacity { get; set; }
}
