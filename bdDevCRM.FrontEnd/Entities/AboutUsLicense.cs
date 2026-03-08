using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class AboutUsLicense
{
    public int? AssemblyId { get; set; }

    public int AboutUsLicenseId { get; set; }

    public string? LicenseFor { get; set; }

    public string? ProductCode { get; set; }

    public string? CodeBaseVersion { get; set; }

    public string? LicenseNumber { get; set; }

    public string? LicenseType { get; set; }

    public string? Sbulicense { get; set; }

    public string? LocationLicense { get; set; }

    public string? UserLicense { get; set; }

    public string? ServerId { get; set; }

    public int? IsActive { get; set; }
}
