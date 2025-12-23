using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class ServiceMaster
{
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public int Status { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<EventQuery> EventQueries { get; set; } = new List<EventQuery>();

    public virtual ICollection<PackageService> PackageServices { get; set; } = new List<PackageService>();
}
