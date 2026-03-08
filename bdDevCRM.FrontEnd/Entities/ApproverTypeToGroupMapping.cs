using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class ApproverTypeToGroupMapping
{
    public int ApproverTypeMapId { get; set; }

    public int? ApproverTypeId { get; set; }

    public int? ModuleId { get; set; }

    public int? GroupId { get; set; }

    public virtual ApproverType? ApproverType { get; set; }
}
