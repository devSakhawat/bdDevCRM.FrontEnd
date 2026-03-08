using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class ApproverHistory
{
    public int AssignApproverId { get; set; }

    public int ApproverId { get; set; }

    public int HrRecordId { get; set; }

    public int ModuleId { get; set; }

    public int Type { get; set; }

    public int IsNew { get; set; }

    public int? SortOrder { get; set; }

    public bool? IsActive { get; set; }

    public int? IsParallel { get; set; }

    public int? DeleteBy { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
