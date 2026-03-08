using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmCountry
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public string? CountryCode { get; set; }

    public int? Status { get; set; }
}
