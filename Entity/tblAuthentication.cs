using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class tblAuthentication
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string UserCode { get; set; } = null!;

    public string username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int UserTypeId { get; set; }

    public bool isActive { get; set; }

    public DateTime CreationDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public virtual SignUpUser User { get; set; } = null!;

    public virtual UserType UserType { get; set; } = null!;
}
