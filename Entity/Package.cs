using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class Package
{
    public int Id { get; set; }

    public string PkgName { get; set; } = null!;

    public int MinCapacity { get; set; }

    public int MaxCapacity { get; set; }

    public decimal Price { get; set; }

    public int PkgServiceId { get; set; }

    public int Status { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<PackageService> PackageServices { get; set; } = new List<PackageService>();
}
