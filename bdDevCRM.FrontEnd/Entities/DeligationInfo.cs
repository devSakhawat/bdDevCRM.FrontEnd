using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DeligationInfo
{
    public int DeligationId { get; set; }

    public int? HrRecordId { get; set; }

    public int? DeligatedHrRecordId { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? ToDate { get; set; }

    public int? IsActive { get; set; }
}
