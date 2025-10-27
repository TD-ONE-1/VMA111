using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class SignUpUser
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? Date { get; set; }

    public bool? Status { get; set; }
}
