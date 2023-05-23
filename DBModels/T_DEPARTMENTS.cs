using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RRHHApi.DBModels;

public partial class T_DEPARTMENTS
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public T_DEPARTMENTS()
    {
        T_EMPLOYEES = new HashSet<T_EMPLOYEES>();
    }
    [Key]
    public int DEPARTMENT_ID { get; set; }

    public string DEPARTMENT_NAME { get; set; } = null!;

    public int? MANAGER_ID { get; set; }

    public int? LOCATION_ID { get; set; }

    public virtual T_LOCATIONS? LOCATION { get; set; }

    public virtual T_EMPLOYEES? MANAGER { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<T_EMPLOYEES> T_EMPLOYEES { get; set; } = new List<T_EMPLOYEES>();

    public virtual ICollection<T_JOB_HISTORY> T_JOB_HISTORY { get; set; } = new List<T_JOB_HISTORY>();
}
