using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmYear
{
    public int YearId { get; set; }

    public string YearName { get; set; } = null!;

    public string? YearCode { get; set; }

    public bool? Status { get; set; }
}
