using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Competencies
{
    public int Id { get; set; }

    public string? CompetencyName { get; set; }

    public int? CompetencyType { get; set; }

    public int? IsDepartmentHead { get; set; }

    public int? IsActive { get; set; }
}
