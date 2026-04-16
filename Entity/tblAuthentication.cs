using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class tblAuthentication
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int UserTypeId { get; set; }

    public bool isActive { get; set; }

    public DateTime CreationDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ShopBranch> ShopBranches { get; set; } = new List<ShopBranch>();

    public virtual UserType UserType { get; set; } = null!;
}
