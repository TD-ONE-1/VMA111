using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class PackageService
{
    public int Id { get; set; }

    public int PackageId { get; set; }

    public int ServiceId { get; set; }

    public int Status { get; set; }

    public bool IsActive { get; set; }

    public virtual Package Package { get; set; } = null!;

    public virtual ServiceMaster Service { get; set; } = null!;
}
