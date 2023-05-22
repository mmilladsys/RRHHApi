using System;
using System.Collections.Generic;

namespace RRHHApi.DBModels;

public partial class T_LOCATIONS
{
    public byte LOCATION_ID { get; set; }

    public string? STREET_ADDRESS { get; set; }

    public string? POSTAL_CODE { get; set; }

    public string CITY { get; set; } = null!;

    public string? STATE_PROVINCE { get; set; }

    public string? COUNTRY_ID { get; set; }

    public virtual T_COUNTRIES? COUNTRY { get; set; }

    public virtual ICollection<T_DEPARTMENTS> T_DEPARTMENTS { get; set; } = new List<T_DEPARTMENTS>();
}
