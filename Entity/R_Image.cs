using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class R_Image
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public string ImageType { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
