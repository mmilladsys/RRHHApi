using System;
using System.Collections.Generic;

namespace RRHHApi.DBModels;

public partial class T_EMPLOYEES
{
    public int EMPLOYEE_ID { get; set; }

    public string? FIRST_NAME { get; set; }

    public string LAST_NAME { get; set; } = null!;

    public string EMAIL { get; set; } = null!;

    public string? PHONE_NUMBER { get; set; }

    public DateTime HIRE_DATE { get; set; }

    public string JOB_ID { get; set; } = null!;

    public decimal? SALARY { get; set; }

    public decimal? COMMISSION_PCT { get; set; }

    public int? MANAGER_ID { get; set; }

    public byte? DEPARTMENT_ID { get; set; }

    public virtual T_DEPARTMENTS DEPARTMENT { get; set; }

    public virtual ICollection<T_EMPLOYEES> InverseMANAGER { get; set; } = new List<T_EMPLOYEES>();

    public virtual T_JOBS JOB { get; set; } = null!;

    public virtual T_EMPLOYEES? MANAGER { get; set; }

    public virtual ICollection<T_DEPARTMENTS> T_DEPARTMENTS { get; set; } = new List<T_DEPARTMENTS>();

    public virtual ICollection<T_JOB_HISTORY> T_JOB_HISTORY { get; set; } = new List<T_JOB_HISTORY>();
}
