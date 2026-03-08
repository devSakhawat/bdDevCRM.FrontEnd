using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class ReportBuilder
{
    public int ReportHeaderId { get; set; }

    public string? ReportHeader { get; set; }

    public string? ReportTitle { get; set; }

    public int? QueryType { get; set; }

    public string? QueryText { get; set; }

    public int? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? OrderByColumn { get; set; }
}
