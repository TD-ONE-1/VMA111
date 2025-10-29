using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class Resturant
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<ResturantConfigration> ResturantConfigrations { get; set; } = new List<ResturantConfigration>();

    public virtual ICollection<ResturantOffer> ResturantOffers { get; set; } = new List<ResturantOffer>();
}
