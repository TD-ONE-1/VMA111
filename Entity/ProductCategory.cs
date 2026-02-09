using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string CategoryType { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
