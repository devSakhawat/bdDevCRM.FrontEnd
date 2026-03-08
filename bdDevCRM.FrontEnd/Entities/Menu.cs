using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Menu
{
    public int MenuId { get; set; }

    public int ModuleId { get; set; }

    public string MenuName { get; set; } = null!;

    public string? MenuPath { get; set; }

    public int? ParentMenu { get; set; }

    public int? Sororder { get; set; }

    public int? Todo { get; set; }

    public int? IsActive { get; set; }
}
