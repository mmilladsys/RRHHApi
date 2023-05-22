using System;
using System.Collections.Generic;

namespace RRHHApi.DBModels;

public partial class T_JOBS
{
    public string JOB_ID { get; set; } = null!;

    public string JOB_TITLE { get; set; } = null!;

    public int? MIN_SALARY { get; set; }

    public int? MAX_SALARY { get; set; }

    public virtual ICollection<T_EMPLOYEES> T_EMPLOYEES { get; set; } = new List<T_EMPLOYEES>();

    public virtual ICollection<T_JOB_HISTORY> T_JOB_HISTORY { get; set; } = new List<T_JOB_HISTORY>();
}
