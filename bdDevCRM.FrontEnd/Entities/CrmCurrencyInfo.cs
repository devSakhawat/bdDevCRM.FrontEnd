using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmCurrencyInfo
{
    public int CurrencyId { get; set; }

    public string? CurrencyName { get; set; }

    public int? IsDefault { get; set; }

    public int? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
