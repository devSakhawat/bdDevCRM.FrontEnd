using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class ApproverOrder
{
    public int ApproverOrderId { get; set; }

    public string? OrderTitle { get; set; }

    public int? ModuleId { get; set; }

    public int? ApproverTypeId { get; set; }

    public bool? IsEditable { get; set; }
}
