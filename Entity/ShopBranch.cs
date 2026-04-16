using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class ShopBranch
{
    public int BranchID { get; set; }

    public int ShopkeeperId { get; set; }

    public string BranchName { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;

    public bool Status { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual tblAuthentication User { get; set; } = null!;
}
