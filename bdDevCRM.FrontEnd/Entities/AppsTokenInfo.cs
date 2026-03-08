using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class AppsTokenInfo
{
    public int AppsTokenInfoId { get; set; }

    public string? AppsUserId { get; set; }

    public string? EmployeeId { get; set; }

    public string? TokenNumber { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime? ExpiredDate { get; set; }
}
