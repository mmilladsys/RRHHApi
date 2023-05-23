using System;
using System.Collections.Generic;

namespace RRHHApi.DBModels;

public partial class T_JOB_HISTORY
{
    public int EMPLOYEE_ID { get; set; }

    public DateTime START_DATE { get; set; }

    public DateTime END_DATE { get; set; }

    public string JOB_ID { get; set; } = null!;

    public int? DEPARTMENT_ID { get; set; }

    public virtual T_DEPARTMENTS? DEPARTMENT { get; set; }

    public virtual T_EMPLOYEES EMPLOYEE { get; set; } = null!;

    public virtual T_JOBS JOB { get; set; } = null!;
}
