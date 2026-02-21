using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class Package
{
    public long Id { get; set; }

    public string PkgName { get; set; } = null!;

    public int MinCapacity { get; set; }

    public int MaxCapacity { get; set; }

    public decimal Price { get; set; }

    public long Status { get; set; }

    public bool isActive { get; set; }
}
