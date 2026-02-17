using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class MealType
{
    public int Id { get; set; }

    public string MealTypeName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<EidReservation> EidReservations { get; set; } = new List<EidReservation>();
}
