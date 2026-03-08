using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmMonth
{
    public int MonthId { get; set; }

    public string MonthName { get; set; } = null!;

    public string? MonthCode { get; set; }

    public bool? Status { get; set; }
}
