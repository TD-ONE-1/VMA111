using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class Shopkeeper
{
    public int ShopkeeperId { get; set; }

    public string ShopkeeperName { get; set; } = null!;

    public string BusinessName { get; set; } = null!;

    public int BusinessTypeId { get; set; }

    public string Address { get; set; } = null!;

    public string NTN { get; set; } = null!;

    public string CNIC { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string Website { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool Status { get; set; }

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;

    public int RatingId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductPurchase> ProductPurchases { get; set; } = new List<ProductPurchase>();
}
