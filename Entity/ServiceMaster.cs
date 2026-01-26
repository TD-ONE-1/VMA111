using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class ServiceMaster
{
    public int Id { get; set; }

    public string? ServiceName { get; set; }

    public int? Status { get; set; }

    public bool? IsActive { get; set; }
}
