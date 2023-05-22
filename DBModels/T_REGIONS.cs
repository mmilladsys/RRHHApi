using System;
using System.Collections.Generic;

namespace RRHHApi.DBModels;

public partial class T_REGIONS
{
    public decimal REGION_ID { get; set; }

    public string? REGION_NAME { get; set; }

    public virtual ICollection<T_COUNTRIES> T_COUNTRIES { get; set; } = new List<T_COUNTRIES>();
}
