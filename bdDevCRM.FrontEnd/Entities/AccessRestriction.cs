using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class AccessRestriction
{
    public int AccessRestrictionId { get; set; }

    public int HrRecordId { get; set; }

    public int ReferenceId { get; set; }

    public int ReferenceType { get; set; }

    public DateTime? AccessDate { get; set; }

    public int? AccessBy { get; set; }

    public int? ParentReference { get; set; }

    public int? ChiledParentReference { get; set; }

    public int? RestrictionType { get; set; }

    public int? GroupId { get; set; }
}
