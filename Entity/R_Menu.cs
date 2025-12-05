using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class R_Menu
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public int OfferId { get; set; }

    public string ItemName { get; set; } = null!;

    public string ItemDetail { get; set; } = null!;

    public int Price { get; set; }

    public int DiscountedPrice { get; set; }

    public byte[] ItemImage { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual R_Offer Offer { get; set; } = null!;
}
