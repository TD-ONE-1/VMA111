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

    public virtual UserType UserType { get; set; } = null!;
}
