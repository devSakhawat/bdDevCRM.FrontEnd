using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class Users
{
    public int UserId { get; set; }

    public int? CompanyId { get; set; }

    public string? LoginId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    /// <summary>
    /// EmployeeId As HrRecordId
    /// </summary>
    public int? EmployeeId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public int? FailedLoginNo { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsExpired { get; set; }

    public string? Theme { get; set; }

    public int? AccessParentCompany { get; set; }

    public int? DefaultDashboard { get; set; }

    public bool? IsSystemUser { get; set; }
}
