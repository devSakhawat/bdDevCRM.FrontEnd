using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class DmsDocumentAccessLog
{
    public long LogId { get; set; }

    public int DocumentId { get; set; }

    public string? AccessedByUserId { get; set; }

    public DateTime? AccessDateTime { get; set; }

    public string Action { get; set; } = null!;

    public string? IpAddress { get; set; }

    public string? DeviceInfo { get; set; }

    public string? MacAddress { get; set; }

    public string? Notes { get; set; }

    public virtual DmsDocument Document { get; set; } = null!;
}
