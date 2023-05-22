using System;
using System.Collections.Generic;

namespace RRHHApi.DBModels;

public partial class T_COUNTRIES
{
    public string COUNTRY_ID { get; set; } = null!;

    public string? COUNTRY_NAME { get; set; }

    public decimal? REGION_ID { get; set; }

    public virtual T_REGIONS? REGION { get; set; }

    public virtual ICollection<T_LOCATIONS> T_LOCATIONS { get; set; } = new List<T_LOCATIONS>();
}
