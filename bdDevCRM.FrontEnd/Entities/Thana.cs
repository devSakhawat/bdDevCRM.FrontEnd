using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Thana
{
    public int ThanaId { get; set; }

    public int DistrictId { get; set; }

    public string? ThanaName { get; set; }

    public string? ThanaCode { get; set; }

    public int? Status { get; set; }

    public string? ThanaNameBn { get; set; }
}
