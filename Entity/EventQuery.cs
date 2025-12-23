using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class EventQuery
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string ContactPersonName { get; set; } = null!;

    public string CellNumber { get; set; } = null!;

    public DateTime BookingDate { get; set; }

    public int NoOfPeople { get; set; }

    public int EventTypeId { get; set; }

    public int ServiceTypeId { get; set; }

    public TimeOnly Timing { get; set; }

    public long Status { get; set; }

    public DateTime EnquiryDate { get; set; }

    public bool IsActive { get; set; }

    public virtual R_Event EventType { get; set; } = null!;

    public virtual ServiceMaster ServiceType { get; set; } = null!;
}
