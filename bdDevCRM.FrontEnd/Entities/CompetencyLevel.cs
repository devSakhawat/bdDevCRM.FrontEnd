using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CompetencyLevel
{
    public int LevelId { get; set; }

    public string? LevelTitle { get; set; }

    public string? Remarks { get; set; }
}
