using System;
using System.Collections.Generic;

namespace RMS.Entity;

public partial class UserType
{
    public int Id { get; set; }

    public string UserTypes { get; set; } = null!;

    public virtual ICollection<tblAuthenticationJovee> tblAuthenticationJovees { get; set; } = new List<tblAuthenticationJovee>();

    public virtual ICollection<tblAuthentication> tblAuthentications { get; set; } = new List<tblAuthentication>();
}
