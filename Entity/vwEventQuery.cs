using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class vwEventQuery
{
    public int id { get; set; }

    public string ContactPersonName { get; set; } = null!;

    public string CellNumber { get; set; } = null!;

    public int NoOfPeople { get; set; }

    public string? Timing { get; set; }

    public long Status { get; set; }

    public bool IsActive { get; set; }

    public DateOnly? EnquiryDate { get; set; }

    public DateOnly? BookingDate { get; set; }

    public string UserName { get; set; } = null!;

    public string ServiceName { get; set; } = null!;

    public string EventType { get; set; } = null!;
}
