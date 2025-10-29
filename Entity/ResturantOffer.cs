using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class ResturantOffer
{
    public int Id { get; set; }

    public int ResturantId { get; set; }

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public virtual Resturant Resturant { get; set; } = null!;

    public virtual ICollection<ResturantConfigration> ResturantConfigrations { get; set; } = new List<ResturantConfigration>();
}
