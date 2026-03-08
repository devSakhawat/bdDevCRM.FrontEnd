using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class WfAction
{
    public int WfactionId { get; set; }

    public int WfstateId { get; set; }

    public string ActionName { get; set; } = null!;

    public int NextStateId { get; set; }

    public int? EmailAlert { get; set; }

    public int? SmsAlert { get; set; }

    public int? AcSortOrder { get; set; }
}
