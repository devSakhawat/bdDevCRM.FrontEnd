using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class AuditTrail
{
    public int AuditId { get; set; }

    public int UserId { get; set; }

    public string? ClientUser { get; set; }

    public string? ClientIp { get; set; }

    public string? Shortdescription { get; set; }

    public string? AuditType { get; set; }

    public string? AuditDescription { get; set; }

    public DateTime? ActionDate { get; set; }

    public string? RequestedUrl { get; set; }

    public string? AuditStatus { get; set; }
}
