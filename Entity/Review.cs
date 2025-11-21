using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class Review
{
    public int Id { get; set; }

    public int FoodQuality { get; set; }

    public int FoodTaste { get; set; }

    public int Rating { get; set; }

    public string Remarks { get; set; } = null!;
}
