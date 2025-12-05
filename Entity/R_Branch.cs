using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class R_Branch
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<R_Offer> R_Offers { get; set; } = new List<R_Offer>();

    public virtual ICollection<ReservationRequest> ReservationRequests { get; set; } = new List<ReservationRequest>();
}
