using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class WfState
{
    public int WfstateId { get; set; }

    public string StateName { get; set; } = null!;

    public int MenuId { get; set; }

    public bool? IsDefaultStart { get; set; }

    public int? IsClosed { get; set; }

    public int? Sequence { get; set; }
}
