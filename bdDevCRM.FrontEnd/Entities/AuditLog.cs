using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class AuditLog
{
    public int AuditId { get; set; }

    public int HrRecordId { get; set; }

    public string? ClientUser { get; set; }

    public string? ClientIp { get; set; }

    public string? MacAddress { get; set; }

    public string? BrowserInfo { get; set; }

    public int? AuditTypeId { get; set; }

    public string? AuditDetails { get; set; }

    public DateTime? AuditDate { get; set; }

    public string? RequestedUrl { get; set; }

    public string? ReferrerUrl { get; set; }

    public string? DomainName { get; set; }

    public string? ActionName { get; set; }

    public string? ControllerName { get; set; }

    public string? RequestedParams { get; set; }

    public string? TableName { get; set; }

    public int? IdentityInTable { get; set; }

    public int? MenuId { get; set; }

    public int? ModuleId { get; set; }

    public string? AuditStatus { get; set; }

    public string? ExceptionLog { get; set; }
}
