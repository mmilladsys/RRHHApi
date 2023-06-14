using System;
using System.Collections.Generic;

namespace RRHHApi.DBModels;

public partial class T_USERS
{
    public short ID_USER { get; set; }

    public string? USER_MAIL { get; set; }

    public string? PASSWORD { get; set; }

    public string? USER_NAME { get; set; }

    public string? ROLE { get; set; }
}
