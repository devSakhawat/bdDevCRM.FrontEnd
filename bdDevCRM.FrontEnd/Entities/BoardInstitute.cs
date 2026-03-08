using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class BoardInstitute
{
    public int BoardInstituteId { get; set; }

    public string? BoardInstituteName { get; set; }

    public int? IsActive { get; set; }
}
