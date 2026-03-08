using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CurencyRate
{
    public int CurencyRateId { get; set; }

    public int CurrencyId { get; set; }

    public decimal? CurrencyRateRation { get; set; }

    public DateTime? CurrencyMonth { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }
}
