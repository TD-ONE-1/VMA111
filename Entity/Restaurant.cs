using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class Restaurant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string About_Description { get; set; } = null!;

    public string CuisineType { get; set; } = null!;

    public string PriceRange { get; set; } = null!;

    public bool IsActive { get; set; }
}
