using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class tblAuthentication
{
    public int Id { get; set; }

    public string UserCode { get; set; } = null!;

    public string username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool isActive { get; set; }

    public DateTime? creationDate { get; set; }

    public string? createdBy { get; set; }
}
